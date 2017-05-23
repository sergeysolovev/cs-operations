def op(k):
    lines = ["from s" + str(n) + " in FindNthPrime(s" + str(n-1) + ")" for n in range(1, k+1)]
    body = reduce(lambda x, y: x + " " + y, lines, "")
    return "public static Operation<string> PrimeNumbersQuery%s => from s0 in FindNthPrime(1) %s select $\"{s%s}th prime number is {s%s}\";" % (k, body, k-1, k)

def sqrt(k):
    lines = ["from r" + str(n) + " in GetSqrt(r" + str(n-1) + ")" for n in range(1, k+1)]
    body = reduce(lambda x, y: x + " " + y, lines, "")
    return "public static Operation<double> GetSqrt%s { get { return from r0 in GetSqrt() %s select r%s; } }" % (k, body, k)


csfile = open("Queries.cs.txt", "w")
csfile.write(op(10) + "\r\n")
csfile.write(sqrt(150) + "\r\n")
csfile.close()