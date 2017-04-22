using System;
using System.Diagnostics;

namespace Operations
{
    public class Program
    {
        public static Fx<double> LinqFx150 { get { return from r0 in RandomDoubleFx()  from r1 in RandomDoubleFx(r0) from r2 in RandomDoubleFx(r1) from r3 in RandomDoubleFx(r2) from r4 in RandomDoubleFx(r3) from r5 in RandomDoubleFx(r4) from r6 in RandomDoubleFx(r5) from r7 in RandomDoubleFx(r6) from r8 in RandomDoubleFx(r7) from r9 in RandomDoubleFx(r8) from r10 in RandomDoubleFx(r9) from r11 in RandomDoubleFx(r10) from r12 in RandomDoubleFx(r11) from r13 in RandomDoubleFx(r12) from r14 in RandomDoubleFx(r13) from r15 in RandomDoubleFx(r14) from r16 in RandomDoubleFx(r15) from r17 in RandomDoubleFx(r16) from r18 in RandomDoubleFx(r17) from r19 in RandomDoubleFx(r18) from r20 in RandomDoubleFx(r19) from r21 in RandomDoubleFx(r20) from r22 in RandomDoubleFx(r21) from r23 in RandomDoubleFx(r22) from r24 in RandomDoubleFx(r23) from r25 in RandomDoubleFx(r24) from r26 in RandomDoubleFx(r25) from r27 in RandomDoubleFx(r26) from r28 in RandomDoubleFx(r27) from r29 in RandomDoubleFx(r28) from r30 in RandomDoubleFx(r29) from r31 in RandomDoubleFx(r30) from r32 in RandomDoubleFx(r31) from r33 in RandomDoubleFx(r32) from r34 in RandomDoubleFx(r33) from r35 in RandomDoubleFx(r34) from r36 in RandomDoubleFx(r35) from r37 in RandomDoubleFx(r36) from r38 in RandomDoubleFx(r37) from r39 in RandomDoubleFx(r38) from r40 in RandomDoubleFx(r39) from r41 in RandomDoubleFx(r40) from r42 in RandomDoubleFx(r41) from r43 in RandomDoubleFx(r42) from r44 in RandomDoubleFx(r43) from r45 in RandomDoubleFx(r44) from r46 in RandomDoubleFx(r45) from r47 in RandomDoubleFx(r46) from r48 in RandomDoubleFx(r47) from r49 in RandomDoubleFx(r48) from r50 in RandomDoubleFx(r49) from r51 in RandomDoubleFx(r50) from r52 in RandomDoubleFx(r51) from r53 in RandomDoubleFx(r52) from r54 in RandomDoubleFx(r53) from r55 in RandomDoubleFx(r54) from r56 in RandomDoubleFx(r55) from r57 in RandomDoubleFx(r56) from r58 in RandomDoubleFx(r57) from r59 in RandomDoubleFx(r58) from r60 in RandomDoubleFx(r59) from r61 in RandomDoubleFx(r60) from r62 in RandomDoubleFx(r61) from r63 in RandomDoubleFx(r62) from r64 in RandomDoubleFx(r63) from r65 in RandomDoubleFx(r64) from r66 in RandomDoubleFx(r65) from r67 in RandomDoubleFx(r66) from r68 in RandomDoubleFx(r67) from r69 in RandomDoubleFx(r68) from r70 in RandomDoubleFx(r69) from r71 in RandomDoubleFx(r70) from r72 in RandomDoubleFx(r71) from r73 in RandomDoubleFx(r72) from r74 in RandomDoubleFx(r73) from r75 in RandomDoubleFx(r74) from r76 in RandomDoubleFx(r75) from r77 in RandomDoubleFx(r76) from r78 in RandomDoubleFx(r77) from r79 in RandomDoubleFx(r78) from r80 in RandomDoubleFx(r79) from r81 in RandomDoubleFx(r80) from r82 in RandomDoubleFx(r81) from r83 in RandomDoubleFx(r82) from r84 in RandomDoubleFx(r83) from r85 in RandomDoubleFx(r84) from r86 in RandomDoubleFx(r85) from r87 in RandomDoubleFx(r86) from r88 in RandomDoubleFx(r87) from r89 in RandomDoubleFx(r88) from r90 in RandomDoubleFx(r89) from r91 in RandomDoubleFx(r90) from r92 in RandomDoubleFx(r91) from r93 in RandomDoubleFx(r92) from r94 in RandomDoubleFx(r93) from r95 in RandomDoubleFx(r94) from r96 in RandomDoubleFx(r95) from r97 in RandomDoubleFx(r96) from r98 in RandomDoubleFx(r97) from r99 in RandomDoubleFx(r98) from r100 in RandomDoubleFx(r99) from r101 in RandomDoubleFx(r100) from r102 in RandomDoubleFx(r101) from r103 in RandomDoubleFx(r102) from r104 in RandomDoubleFx(r103) from r105 in RandomDoubleFx(r104) from r106 in RandomDoubleFx(r105) from r107 in RandomDoubleFx(r106) from r108 in RandomDoubleFx(r107) from r109 in RandomDoubleFx(r108) from r110 in RandomDoubleFx(r109) from r111 in RandomDoubleFx(r110) from r112 in RandomDoubleFx(r111) from r113 in RandomDoubleFx(r112) from r114 in RandomDoubleFx(r113) from r115 in RandomDoubleFx(r114) from r116 in RandomDoubleFx(r115) from r117 in RandomDoubleFx(r116) from r118 in RandomDoubleFx(r117) from r119 in RandomDoubleFx(r118) from r120 in RandomDoubleFx(r119) from r121 in RandomDoubleFx(r120) from r122 in RandomDoubleFx(r121) from r123 in RandomDoubleFx(r122) from r124 in RandomDoubleFx(r123) from r125 in RandomDoubleFx(r124) from r126 in RandomDoubleFx(r125) from r127 in RandomDoubleFx(r126) from r128 in RandomDoubleFx(r127) from r129 in RandomDoubleFx(r128) from r130 in RandomDoubleFx(r129) from r131 in RandomDoubleFx(r130) from r132 in RandomDoubleFx(r131) from r133 in RandomDoubleFx(r132) from r134 in RandomDoubleFx(r133) from r135 in RandomDoubleFx(r134) from r136 in RandomDoubleFx(r135) from r137 in RandomDoubleFx(r136) from r138 in RandomDoubleFx(r137) from r139 in RandomDoubleFx(r138) from r140 in RandomDoubleFx(r139) from r141 in RandomDoubleFx(r140) from r142 in RandomDoubleFx(r141) from r143 in RandomDoubleFx(r142) from r144 in RandomDoubleFx(r143) from r145 in RandomDoubleFx(r144) from r146 in RandomDoubleFx(r145) from r147 in RandomDoubleFx(r146) from r148 in RandomDoubleFx(r147) from r149 in RandomDoubleFx(r148) from r150 in RandomDoubleFx(r149) select r150; } }
        public static LazyAsync<double> Linq150 { get { return from r0 in RandomDouble()  from r1 in RandomDouble(r0) from r2 in RandomDouble(r1) from r3 in RandomDouble(r2) from r4 in RandomDouble(r3) from r5 in RandomDouble(r4) from r6 in RandomDouble(r5) from r7 in RandomDouble(r6) from r8 in RandomDouble(r7) from r9 in RandomDouble(r8) from r10 in RandomDouble(r9) from r11 in RandomDouble(r10) from r12 in RandomDouble(r11) from r13 in RandomDouble(r12) from r14 in RandomDouble(r13) from r15 in RandomDouble(r14) from r16 in RandomDouble(r15) from r17 in RandomDouble(r16) from r18 in RandomDouble(r17) from r19 in RandomDouble(r18) from r20 in RandomDouble(r19) from r21 in RandomDouble(r20) from r22 in RandomDouble(r21) from r23 in RandomDouble(r22) from r24 in RandomDouble(r23) from r25 in RandomDouble(r24) from r26 in RandomDouble(r25) from r27 in RandomDouble(r26) from r28 in RandomDouble(r27) from r29 in RandomDouble(r28) from r30 in RandomDouble(r29) from r31 in RandomDouble(r30) from r32 in RandomDouble(r31) from r33 in RandomDouble(r32) from r34 in RandomDouble(r33) from r35 in RandomDouble(r34) from r36 in RandomDouble(r35) from r37 in RandomDouble(r36) from r38 in RandomDouble(r37) from r39 in RandomDouble(r38) from r40 in RandomDouble(r39) from r41 in RandomDouble(r40) from r42 in RandomDouble(r41) from r43 in RandomDouble(r42) from r44 in RandomDouble(r43) from r45 in RandomDouble(r44) from r46 in RandomDouble(r45) from r47 in RandomDouble(r46) from r48 in RandomDouble(r47) from r49 in RandomDouble(r48) from r50 in RandomDouble(r49) from r51 in RandomDouble(r50) from r52 in RandomDouble(r51) from r53 in RandomDouble(r52) from r54 in RandomDouble(r53) from r55 in RandomDouble(r54) from r56 in RandomDouble(r55) from r57 in RandomDouble(r56) from r58 in RandomDouble(r57) from r59 in RandomDouble(r58) from r60 in RandomDouble(r59) from r61 in RandomDouble(r60) from r62 in RandomDouble(r61) from r63 in RandomDouble(r62) from r64 in RandomDouble(r63) from r65 in RandomDouble(r64) from r66 in RandomDouble(r65) from r67 in RandomDouble(r66) from r68 in RandomDouble(r67) from r69 in RandomDouble(r68) from r70 in RandomDouble(r69) from r71 in RandomDouble(r70) from r72 in RandomDouble(r71) from r73 in RandomDouble(r72) from r74 in RandomDouble(r73) from r75 in RandomDouble(r74) from r76 in RandomDouble(r75) from r77 in RandomDouble(r76) from r78 in RandomDouble(r77) from r79 in RandomDouble(r78) from r80 in RandomDouble(r79) from r81 in RandomDouble(r80) from r82 in RandomDouble(r81) from r83 in RandomDouble(r82) from r84 in RandomDouble(r83) from r85 in RandomDouble(r84) from r86 in RandomDouble(r85) from r87 in RandomDouble(r86) from r88 in RandomDouble(r87) from r89 in RandomDouble(r88) from r90 in RandomDouble(r89) from r91 in RandomDouble(r90) from r92 in RandomDouble(r91) from r93 in RandomDouble(r92) from r94 in RandomDouble(r93) from r95 in RandomDouble(r94) from r96 in RandomDouble(r95) from r97 in RandomDouble(r96) from r98 in RandomDouble(r97) from r99 in RandomDouble(r98) from r100 in RandomDouble(r99) from r101 in RandomDouble(r100) from r102 in RandomDouble(r101) from r103 in RandomDouble(r102) from r104 in RandomDouble(r103) from r105 in RandomDouble(r104) from r106 in RandomDouble(r105) from r107 in RandomDouble(r106) from r108 in RandomDouble(r107) from r109 in RandomDouble(r108) from r110 in RandomDouble(r109) from r111 in RandomDouble(r110) from r112 in RandomDouble(r111) from r113 in RandomDouble(r112) from r114 in RandomDouble(r113) from r115 in RandomDouble(r114) from r116 in RandomDouble(r115) from r117 in RandomDouble(r116) from r118 in RandomDouble(r117) from r119 in RandomDouble(r118) from r120 in RandomDouble(r119) from r121 in RandomDouble(r120) from r122 in RandomDouble(r121) from r123 in RandomDouble(r122) from r124 in RandomDouble(r123) from r125 in RandomDouble(r124) from r126 in RandomDouble(r125) from r127 in RandomDouble(r126) from r128 in RandomDouble(r127) from r129 in RandomDouble(r128) from r130 in RandomDouble(r129) from r131 in RandomDouble(r130) from r132 in RandomDouble(r131) from r133 in RandomDouble(r132) from r134 in RandomDouble(r133) from r135 in RandomDouble(r134) from r136 in RandomDouble(r135) from r137 in RandomDouble(r136) from r138 in RandomDouble(r137) from r139 in RandomDouble(r138) from r140 in RandomDouble(r139) from r141 in RandomDouble(r140) from r142 in RandomDouble(r141) from r143 in RandomDouble(r142) from r144 in RandomDouble(r143) from r145 in RandomDouble(r144) from r146 in RandomDouble(r145) from r147 in RandomDouble(r146) from r148 in RandomDouble(r147) from r149 in RandomDouble(r148) from r150 in RandomDouble(r149) select r150; } }

        public static Fx<double> LinqFx10 { get { return from r0 in RandomDoubleFx()  from r1 in RandomDoubleFx(r0) from r2 in RandomDoubleFx(r1) from r3 in RandomDoubleFx(r2) from r4 in RandomDoubleFx(r3) from r5 in RandomDoubleFx(r4) from r6 in RandomDoubleFx(r5) from r7 in RandomDoubleFx(r6) from r8 in RandomDoubleFx(r7) from r9 in RandomDoubleFx(r8) from r10 in RandomDoubleFx(r9) select r10; } }
        public static LazyAsync<double> Linq10 { get { return from r0 in RandomDouble()  from r1 in RandomDouble(r0) from r2 in RandomDouble(r1) from r3 in RandomDouble(r2) from r4 in RandomDouble(r3) from r5 in RandomDouble(r4) from r6 in RandomDouble(r5) from r7 in RandomDouble(r6) from r8 in RandomDouble(r7) from r9 in RandomDouble(r8) from r10 in RandomDouble(r9) select r10; } }

        public static LazyAsync<double> RandomDouble(double seed = 0)
        {
            return new LazyAsync<double>(() => GetRandomDouble(
                (seed != 0) ? (int)seed * 100 : DateTime.Now.Millisecond));
        }

        public static Fx<double> RandomDoubleFx(double seed = 0)
        {
            return new Fx<double>(() => GetRandomDouble(
                (seed != 0) ? (int)seed * 100 : DateTime.Now.Millisecond));
        }

        public static double GetRandomDouble(int seed)
        {
            var random = new Random(seed);
            var result = random.NextDouble();
            // Console.WriteLine($"{nameof(GetRandomDouble)} gets called: {result}");
            return result;
        }

        public static void MeasureLazyAsync<T>(
            Func<LazyAsync<T>> getLazyAsync,
            string queryName = "")
        {
            var swBldt = new Stopwatch();
            var swExec = new Stopwatch();

            Console.WriteLine($"Measuring LazyAsync {queryName}");
            Console.WriteLine("Building ...");
            swBldt.Start();
            var lazyAsync = getLazyAsync();
            swBldt.Stop();

            Console.WriteLine("Executing ...");
            swExec.Start();
            var result = lazyAsync.Result;
            swExec.Stop();

            Console.WriteLine($"Result: {lazyAsync.Result}");
            Console.WriteLine($"Build time {swBldt.ElapsedTicks}, {swBldt.ElapsedMilliseconds}");
            Console.WriteLine($"Exctn time {swExec.ElapsedTicks}, {swExec.ElapsedMilliseconds}");
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void MeasureFx<T>(
            Func<Fx<T>> getFx,
            string queryName = "")
        {
            var swBldt = new Stopwatch();
            var swExec = new Stopwatch();

            Console.WriteLine($"Measuring Fx {queryName}");
            Console.WriteLine("Building ...");
            swBldt.Start();
            var fx = getFx();
            swBldt.Stop();

            Console.WriteLine("Executing ...");
            swExec.Start();
            var result = fx.Result;
            swExec.Stop();

            Console.WriteLine($"Result: succeeded: {fx.Succeeded}");
            if (fx.Succeeded)
            {
                Console.WriteLine($"Result: {fx.Result}");
            }
            Console.WriteLine($"Build time {swBldt.ElapsedTicks}, {swBldt.ElapsedMilliseconds}");
            Console.WriteLine($"Exctn time {swExec.ElapsedTicks}, {swExec.ElapsedMilliseconds}");
            Console.WriteLine();
            Console.WriteLine();
        }

        public static Fx<double> FxQuery =>
            from r1 in RandomDoubleFx()
            from r2 in RandomDoubleFx(r1)
            let s = r1 + r2
            where s >= 1.5
            select s;

        public static void Main(string[] args)
        {
            //MeasureLazyAsync<double>(() => Linq150);
            MeasureFx<double>(() => LinqFx150);
        }
    }
}
