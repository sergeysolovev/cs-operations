def linq(k):
    lines = ["from r" + str(n) + " in RandomDouble(r" + str(n-1) + ")" for n in range(1, k+1)]
    body = reduce(lambda x, y: x + " " + y, lines, "")
    return "public static LazyAsync<double> Linq%s { get { return from r0 in RandomDouble() %s select r%s; } }" % (k, body, k)

def linqfx(k):
    lines = ["from r" + str(n) + " in RandomDoubleFx(r" + str(n-1) + ")" for n in range(1, k+1)]
    body = reduce(lambda x, y: x + " " + y, lines, "")
    return "public static Fx<double> LinqFx%s { get { return from r0 in RandomDoubleFx() %s select r%s; } }" % (k, body, k)

def linqgx(k):
    lines = ["from r" + str(n) + " in RandomDoubleGx(r" + str(n-1) + ")" for n in range(1, k+1)]
    body = reduce(lambda x, y: x + " " + y, lines, "")
    return "public static Fx<double> LinqGx%s { get { return from r0 in RandomDoubleFx() %s select r%s; } }" % (k, body, k)


def nolinq(k):
    lines = ["var r" + str(n) + " = RandomDouble(r" + str(n-1) + ".Result);" for n in range(1, k+1)]
    body = reduce(lambda x, y: x + " " + y, lines, "")
    return "public static LazyAsync<double> NoLinq%s { get { var r0 = RandomDouble(); %s return r%s; } }" % (k, body, k)

csfile = open("Queries.cs.txt", "w")
csfile.write(linqfx(150) + "\r\n")
csfile.write(linqgx(150) + "\r\n")
csfile.close()