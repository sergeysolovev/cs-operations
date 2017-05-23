using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Operations
{
    public class Program
    {
        public static long NthPrime(long n)
        {
            int count = 0;
            long a = 2;
            while (count < n) {
                long b = 2;
                int prime = 1;
                while(b * b <= a) {
                    if(a % b == 0) { prime = 0; break; }
                    b++;
                }
                if(prime > 0) { count++; }
                a++;
            }
            return (--a);
        }

        public static async Task MeasureOperation<T>(Func<IOperation<T>> operationFactory)
        {
            var swBldt = new Stopwatch();
            var swExec = new Stopwatch();

            Console.WriteLine("Building operation...");
            swBldt.Start();
            var operation = operationFactory();
            swBldt.Stop();

            Console.WriteLine("Executing operation...");
            swExec.Start();
            var result = await operation;
            swExec.Stop();

            var valueDisplay = result.Succeeded ? result.Result.ToString() : "<NoValue>";
            Console.WriteLine($"Result: {valueDisplay}");
            Console.WriteLine($"Build time {swBldt.ElapsedMilliseconds}");
            Console.WriteLine($"Exctn time {swExec.ElapsedMilliseconds}");
            Console.WriteLine($"Total time {swExec.ElapsedMilliseconds + swBldt.ElapsedMilliseconds}");

            Console.WriteLine();
            Console.WriteLine();
        }

        public static double Sqrt(double value)
        {
            var result = value;
            return result;
        }

        public static IOperation<double> GetSqrt(double value = double.MaxValue)
            => Operation.Return(() => Sqrt(value));

        public static IOperation<long> FindNthPrime(long n)
            => Operation.Return(() => NthPrime(n));

        public static IOperation<string> PrimeNumbersQuery10 => from s0 in FindNthPrime(1) from s1 in FindNthPrime(s0) from s2 in FindNthPrime(s1) from s3 in FindNthPrime(s2) from s4 in FindNthPrime(s3) from s5 in FindNthPrime(s4) from s6 in FindNthPrime(s5) from s7 in FindNthPrime(s6) from s8 in FindNthPrime(s7) from s9 in FindNthPrime(s8) from s10 in FindNthPrime(s9) select $"{s9}th prime number is {s10}";
        public static IOperation<double> GetSqrt150 { get { return from r0 in GetSqrt()  from r1 in GetSqrt(r0) from r2 in GetSqrt(r1) from r3 in GetSqrt(r2) from r4 in GetSqrt(r3) from r5 in GetSqrt(r4) from r6 in GetSqrt(r5) from r7 in GetSqrt(r6) from r8 in GetSqrt(r7) from r9 in GetSqrt(r8) from r10 in GetSqrt(r9) from r11 in GetSqrt(r10) from r12 in GetSqrt(r11) from r13 in GetSqrt(r12) from r14 in GetSqrt(r13) from r15 in GetSqrt(r14) from r16 in GetSqrt(r15) from r17 in GetSqrt(r16) from r18 in GetSqrt(r17) from r19 in GetSqrt(r18) from r20 in GetSqrt(r19) from r21 in GetSqrt(r20) from r22 in GetSqrt(r21) from r23 in GetSqrt(r22) from r24 in GetSqrt(r23) from r25 in GetSqrt(r24) from r26 in GetSqrt(r25) from r27 in GetSqrt(r26) from r28 in GetSqrt(r27) from r29 in GetSqrt(r28) from r30 in GetSqrt(r29) from r31 in GetSqrt(r30) from r32 in GetSqrt(r31) from r33 in GetSqrt(r32) from r34 in GetSqrt(r33) from r35 in GetSqrt(r34) from r36 in GetSqrt(r35) from r37 in GetSqrt(r36) from r38 in GetSqrt(r37) from r39 in GetSqrt(r38) from r40 in GetSqrt(r39) from r41 in GetSqrt(r40) from r42 in GetSqrt(r41) from r43 in GetSqrt(r42) from r44 in GetSqrt(r43) from r45 in GetSqrt(r44) from r46 in GetSqrt(r45) from r47 in GetSqrt(r46) from r48 in GetSqrt(r47) from r49 in GetSqrt(r48) from r50 in GetSqrt(r49) from r51 in GetSqrt(r50) from r52 in GetSqrt(r51) from r53 in GetSqrt(r52) from r54 in GetSqrt(r53) from r55 in GetSqrt(r54) from r56 in GetSqrt(r55) from r57 in GetSqrt(r56) from r58 in GetSqrt(r57) from r59 in GetSqrt(r58) from r60 in GetSqrt(r59) from r61 in GetSqrt(r60) from r62 in GetSqrt(r61) from r63 in GetSqrt(r62) from r64 in GetSqrt(r63) from r65 in GetSqrt(r64) from r66 in GetSqrt(r65) from r67 in GetSqrt(r66) from r68 in GetSqrt(r67) from r69 in GetSqrt(r68) from r70 in GetSqrt(r69) from r71 in GetSqrt(r70) from r72 in GetSqrt(r71) from r73 in GetSqrt(r72) from r74 in GetSqrt(r73) from r75 in GetSqrt(r74) from r76 in GetSqrt(r75) from r77 in GetSqrt(r76) from r78 in GetSqrt(r77) from r79 in GetSqrt(r78) from r80 in GetSqrt(r79) from r81 in GetSqrt(r80) from r82 in GetSqrt(r81) from r83 in GetSqrt(r82) from r84 in GetSqrt(r83) from r85 in GetSqrt(r84) from r86 in GetSqrt(r85) from r87 in GetSqrt(r86) from r88 in GetSqrt(r87) from r89 in GetSqrt(r88) from r90 in GetSqrt(r89) from r91 in GetSqrt(r90) from r92 in GetSqrt(r91) from r93 in GetSqrt(r92) from r94 in GetSqrt(r93) from r95 in GetSqrt(r94) from r96 in GetSqrt(r95) from r97 in GetSqrt(r96) from r98 in GetSqrt(r97) from r99 in GetSqrt(r98) from r100 in GetSqrt(r99) from r101 in GetSqrt(r100) from r102 in GetSqrt(r101) from r103 in GetSqrt(r102) from r104 in GetSqrt(r103) from r105 in GetSqrt(r104) from r106 in GetSqrt(r105) from r107 in GetSqrt(r106) from r108 in GetSqrt(r107) from r109 in GetSqrt(r108) from r110 in GetSqrt(r109) from r111 in GetSqrt(r110) from r112 in GetSqrt(r111) from r113 in GetSqrt(r112) from r114 in GetSqrt(r113) from r115 in GetSqrt(r114) from r116 in GetSqrt(r115) from r117 in GetSqrt(r116) from r118 in GetSqrt(r117) from r119 in GetSqrt(r118) from r120 in GetSqrt(r119) from r121 in GetSqrt(r120) from r122 in GetSqrt(r121) from r123 in GetSqrt(r122) from r124 in GetSqrt(r123) from r125 in GetSqrt(r124) from r126 in GetSqrt(r125) from r127 in GetSqrt(r126) from r128 in GetSqrt(r127) from r129 in GetSqrt(r128) from r130 in GetSqrt(r129) from r131 in GetSqrt(r130) from r132 in GetSqrt(r131) from r133 in GetSqrt(r132) from r134 in GetSqrt(r133) from r135 in GetSqrt(r134) from r136 in GetSqrt(r135) from r137 in GetSqrt(r136) from r138 in GetSqrt(r137) from r139 in GetSqrt(r138) from r140 in GetSqrt(r139) from r141 in GetSqrt(r140) from r142 in GetSqrt(r141) from r143 in GetSqrt(r142) from r144 in GetSqrt(r143) from r145 in GetSqrt(r144) from r146 in GetSqrt(r145) from r147 in GetSqrt(r146) from r148 in GetSqrt(r147) from r149 in GetSqrt(r148) from r150 in GetSqrt(r149) select r150; } }

        public static void Main(string[] args)
        {
        }
    }
}
