# Gestor: lee los CSV de los lenguajes y compara resultados
# Ejecutar en la carpeta donde estan los CSV:  python gestor.py
# Genera: reporte_final.txt y tabla_unificada.csv
import csv
import glob
import math
from collections import defaultdict

PATRON = "resultados_*.csv"
SALIDA_TXT = "reporte_final.txt"
SALIDA_CSV = "tabla_unificada.csv"
ORDEN_LANG = ["C++", "Python", "C#", "Java", "JavaScript"]
N_GRANDE = 100000  # tamano a partir del cual se hace el segundo ranking

salida = []


def p(texto=""):
    print(texto)
    salida.append(texto)


def leer(ruta):
    meta, datos = {}, []
    with open(ruta, newline="", encoding="utf-8-sig") as f:
        for linea in f:
            linea = linea.strip()
            if linea.startswith("#"):
                k, _, v = linea[1:].partition(":")
                meta[k.strip()] = v.strip()
            elif linea:
                datos.append(linea)
    return meta, list(csv.DictReader(datos))


def gmean(valores):
    return math.exp(sum(math.log(v) for v in valores) / len(valores))


def tiempo(v):
    return max(v, 1e-4)


# ---------------------------- Carga ----------------------------
mejor = {}
for ruta in glob.glob(PATRON):
    meta, filas = leer(ruta)
    if not filas:
        continue
    lang = filas[0]["lenguaje"].strip()
    nok = sum(1 for r in filas if r["estado"] == "ok")
    if lang not in mejor or nok > mejor[lang][0]:
        mejor[lang] = (nok, ruta, meta, filas)

if not mejor:
    print("No encontre archivos resultados_*.csv en esta carpeta.")
    raise SystemExit

langs = [l for l in ORDEN_LANG if l in mejor] + [l for l in mejor if l not in ORDEN_LANG]
datos = {}
for l in langs:
    nok, ruta, meta, filas = mejor[l]
    d = {}
    for r in filas:
        if r["estado"] == "ok":
            d[(r["algoritmo"], int(r["n"]), r["tipo"])] = (
                float(r["tiempo_ms"]), int(r["comparaciones"]), int(r["intercambios"]))
        elif r["estado"] != "omitido":
            p("AVISO: %s tiene un resultado con estado %s (%s, n=%s, %s)"
              % (l, r["estado"], r["algoritmo"], r["n"], r["tipo"]))
    datos[l] = d

p("=" * 64)
p("REPORTE FINAL - COMPARACION DE ALGORITMOS DE ORDENAMIENTO")
p("=" * 64)
p()
p("Archivos y hardware usados:")
for l in langs:
    nok, ruta, meta, filas = mejor[l]
    p("- %s (%s, %d resultados validos): %s | %s | %s | %s"
      % (l, ruta, nok, meta.get("cpu", "?"), meta.get("ram", "?"),
         meta.get("so", "?"), meta.get("compilador", "?")))
cpus = set(mejor[l][2].get("cpu", "?") for l in langs)
if len(cpus) > 1:
    p("AVISO: los archivos indican CPUs distintos; la comparacion de lenguajes no seria justa.")
faltan = [l for l in ORDEN_LANG if l not in mejor]
if faltan:
    p("AVISO: faltan resultados de: " + ", ".join(faltan))
p()

# ------------------------ Lenguaje mas rapido ------------------------
comunes = set.intersection(*[set(d) for d in datos.values()])
p("-" * 64)
p("1) LENGUAJE MAS RAPIDO")
p("-" * 64)
p("Solo se comparan los casos que todos los lenguajes ejecutaron (%d casos)." % len(comunes))


def ranking_lenguajes(casos, titulo):
    if not casos:
        p("\n%s: no hay casos en comun." % titulo)
        return None
    tot = {l: 0.0 for l in langs}
    rel = {l: [] for l in langs}
    vic = {l: 0 for l in langs}
    for k in casos:
        ts = {l: tiempo(datos[l][k][0]) for l in langs}
        mn = min(ts.values())
        for l in langs:
            tot[l] += ts[l]
            rel[l].append(ts[l] / mn)
        vic[min(ts, key=ts.get)] += 1
    orden = sorted(langs, key=lambda l: gmean(rel[l]))
    p("\n%s (%d casos)" % (titulo, len(casos)))
    p("%-12s %16s %22s %10s" % ("Lenguaje", "Tiempo total (s)", "Veces mas lento (prom.)", "Victorias"))
    for l in orden:
        p("%-12s %16.2f %22.2fx %10d" % (l, tot[l] / 1000, gmean(rel[l]), vic[l]))
    return orden[0]


g1 = ranking_lenguajes(sorted(comunes), "Todos los casos")
g2 = ranking_lenguajes(sorted(k for k in comunes if k[1] >= N_GRANDE),
                       "Solo arreglos grandes (n >= %d)" % N_GRANDE)
p()
if g1:
    p(">>> Lenguaje mas rapido en general: %s" % g1)
if g2:
    p(">>> Lenguaje mas rapido con arreglos grandes: %s" % g2)
p()

# ------------------------ Algoritmo mas rapido ------------------------
algs = sorted(set(k[0] for d in datos.values() for k in d))
p("-" * 64)
p("2) ALGORITMO MAS RAPIDO")
p("-" * 64)

rel = defaultdict(list)
tot = defaultdict(float)
vic = defaultdict(int)
completos = [(n, t) for (n, t) in set((k[1], k[2]) for k in comunes)
             if all((a, n, t) in comunes for a in algs)]
for l in langs:
    for (n, t) in completos:
        ts = {a: tiempo(datos[l][(a, n, t)][0]) for a in algs}
        mn = min(ts.values())
        for a in algs:
            rel[a].append(ts[a] / mn)
            tot[a] += ts[a]
        vic[min(ts, key=ts.get)] += 1
if rel:
    orden = sorted(algs, key=lambda a: gmean(rel[a]))
    p("\nRanking general (%d escenarios donde corrieron los %d algoritmos en todos los lenguajes)" % (len(completos), len(algs)))
    p("%-10s %16s %22s %10s" % ("Algoritmo", "Tiempo total (s)", "Veces mas lento (prom.)", "Victorias"))
    for a in orden:
        p("%-10s %16.2f %22.2fx %10d" % (a, tot[a] / 1000, gmean(rel[a]), vic[a]))
    p("\n>>> Algoritmo mas rapido en general: %s" % orden[0])

p("\nAlgoritmo mas rapido por escenario (tiempo promedio entre lenguajes):")
p("%-10s %-10s %-10s %14s   %s" % ("n", "tipo", "ganador", "tiempo (ms)", "2.o lugar"))
escs = sorted(set((k[1], k[2]) for k in comunes), key=lambda x: (x[0], ["aleatorio", "ordenado", "inverso"].index(x[1])
              if x[1] in ["aleatorio", "ordenado", "inverso"] else 9))
for (n, t) in escs:
    medias = {}
    for a in algs:
        if (a, n, t) in comunes:
            medias[a] = sum(datos[l][(a, n, t)][0] for l in langs) / len(langs)
    if len(medias) < 2:
        continue
    orden_e = sorted(medias, key=medias.get)
    nota = "" if len(medias) == len(algs) else "  (entre los que se ejecutaron)"
    p("%-10d %-10s %-10s %14.4f   %s%s" % (n, t, orden_e[0], medias[orden_e[0]], orden_e[1], nota))

# --------------- Comparaciones e intercambios por algoritmo ---------------
p()
p("-" * 64)
p("3) COMPARACIONES E INTERCAMBIOS (iguales en todos los lenguajes)")
p("-" * 64)
base = datos[langs[0]]
sc = defaultdict(int)
si = defaultdict(int)
validos = completos
for (n, t) in validos:
    for a in algs:
        sc[a] += base[(a, n, t)][1]
        si[a] += base[(a, n, t)][2]
if validos:
    p("Suma sobre los %d escenarios donde corrieron los %d algoritmos." % (len(validos), len(algs)))
    p("%-10s %20s %20s" % ("Algoritmo", "Comparaciones", "Intercambios"))
    for a in sorted(algs, key=lambda a: sc[a]):
        p("%-10s %20s %20s" % (a, format(sc[a], ","), format(si[a], ",")))
    p("Nota: en Radix las comparaciones son 0 porque no compara elementos.")
    p("Intercambios = swaps (Bubble, Selection, Quick, Heap) o movimientos de elementos (los demas).")

# ---------------------------- Exportar ----------------------------
todas = sorted(set(k for d in datos.values() for k in d))
with open(SALIDA_CSV, "w", newline="", encoding="utf-8") as f:
    w = csv.writer(f)
    w.writerow(["", "", "", "TIEMPO (ms)"] + [""] * (len(langs) - 1) + ["CONTEOS", ""])
    w.writerow(["algoritmo", "n", "tipo"] + list(langs) + ["comparaciones", "intercambios"])
    for k in todas:
        fila = [k[0], k[1], k[2]]
        for l in langs:
            fila.append(datos[l][k][0] if k in datos[l] else "")
        ref = next(datos[l][k] for l in langs if k in datos[l])
        fila += [ref[1], ref[2]]
        w.writerow(fila)

with open(SALIDA_TXT, "w", encoding="utf-8") as f:
    f.write("\n".join(salida) + "\n")
print("\nGuardado: %s y %s" % (SALIDA_TXT, SALIDA_CSV))
