using System;
using System.Diagnostics;

namespace Operations
{
    public class Program
    {
        public static Operation<double> Zero
            => new Operation<double>(() => 0.0);

        public static Operation<double> One
            => new Operation<double>(() => 1.0);

        public static Operation<double> MultiplyByTwo(double x)
            => new Operation<double>(() => x * 2.0);

        public static Operation<double> AddOne(double x)
            => new Operation<double>(() => x + 1.0);

        public static Operation<double> Square(double x)
            => new Operation<double>(() => x * x);

        public static Operation<double> Cube(double x)
            => new Operation<double>(() => x * x * x);

        public static Operation<string> SquareSquare(double x)
            => Square(x).Select(y => $"value: {x}");

        public static Operation<double> RandomDouble
            => new Operation<double>(() => GetRandomDouble());

        public static double GetRandomDouble()
        {
            var random = new Random(DateTime.Now.Millisecond);
            return random.NextDouble();
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Started");
            Console.WriteLine("Processing...");

            var swBldt = new Stopwatch();
            swBldt.Start();
            var query =
                from r1 in RandomDouble
                from r2 in RandomDouble
                from r3 in RandomDouble
                from r4 in RandomDouble
                from r5 in RandomDouble
                from r6 in RandomDouble
                from r7 in RandomDouble
                from r8 in RandomDouble
                from r9 in RandomDouble
                from r10 in RandomDouble
                from r11 in RandomDouble
                from r12 in RandomDouble
                from r13 in RandomDouble
                from r14 in RandomDouble
                // from r15 in RandomDouble
                // from r16 in RandomDouble
                // from r17 in RandomDouble
                // from r18 in RandomDouble
                // from r19 in RandomDouble
                // from r20 in RandomDouble
                // from r21 in RandomDouble
                // from r22 in RandomDouble
                // from r23 in RandomDouble
                // from r24 in RandomDouble
                // from r25 in RandomDouble
                // from r26 in RandomDouble
                // from r27 in RandomDouble
                // from r28 in RandomDouble
                // from r29 in RandomDouble
                // from r30 in RandomDouble
                // from r110 in RandomDouble
                // from r111 in RandomDouble
                // from r112 in RandomDouble
                // from r113 in RandomDouble
                // from r114 in RandomDouble

                // from r115 in RandomDouble
                // from r116 in RandomDouble
                // from r117 in RandomDouble
                // from r118 in RandomDouble
                // from r119 in RandomDouble
                // from r120 in RandomDouble
                // from r121 in RandomDouble
                // from r122 in RandomDouble
                // from r123 in RandomDouble
                // from r124 in RandomDouble
                // from r125 in RandomDouble
                // from r126 in RandomDouble
                // from r127 in RandomDouble
                // from r128 in RandomDouble
                // from r129 in RandomDouble
                // from r130 in RandomDouble
                // from r210 in RandomDouble
                // from r211 in RandomDouble
                // from r212 in RandomDouble
                // from r213 in RandomDouble
                // from r214 in RandomDouble
                // from r215 in RandomDouble
                // from r216 in RandomDouble
                // from r217 in RandomDouble
                // from r218 in RandomDouble
                // from r219 in RandomDouble
                // from r220 in RandomDouble
                // from r221 in RandomDouble
                // from r222 in RandomDouble
                // from r223 in RandomDouble
                // from r224 in RandomDouble
                // from r225 in RandomDouble
                // from r226 in RandomDouble
                // from r227 in RandomDouble
                // from r228 in RandomDouble
                // from r229 in RandomDouble

                // from r230 in RandomDouble
                // from r1110 in RandomDouble
                // from r1111 in RandomDouble
                // from r1112 in RandomDouble
                // from r1113 in RandomDouble
                // from r1114 in RandomDouble
                // from r1115 in RandomDouble
                // from r1116 in RandomDouble
                // from r1117 in RandomDouble
                // from r1118 in RandomDouble
                // from r1119 in RandomDouble
                // from r1120 in RandomDouble
                // from r1121 in RandomDouble
                // from r1122 in RandomDouble
                // from r1123 in RandomDouble
                // from r1124 in RandomDouble
                // from r1125 in RandomDouble
                // from r1126 in RandomDouble
                // from r1127 in RandomDouble
                // from r1128 in RandomDouble
                // from r1129 in RandomDouble
                // from r1130 in RandomDouble
                // from r1210 in RandomDouble
                // from r1211 in RandomDouble
                // from r1212 in RandomDouble
                // from r1213 in RandomDouble
                // from r1214 in RandomDouble
                // from r1215 in RandomDouble
                // from r1216 in RandomDouble
                // from r1217 in RandomDouble
                // from r1218 in RandomDouble
                // from r1219 in RandomDouble
                // from r1220 in RandomDouble
                // from r1221 in RandomDouble
                // from r1222 in RandomDouble
                // from r1223 in RandomDouble
                // from r1224 in RandomDouble
                // from r1225 in RandomDouble
                // from r1226 in RandomDouble
                // from r1227 in RandomDouble
                // from r1228 in RandomDouble
                // from r1229 in RandomDouble
                // from r1230 in RandomDouble
                // from r2110 in RandomDouble
                // from r2111 in RandomDouble
                // from r2112 in RandomDouble
                // from r2113 in RandomDouble
                // from r2114 in RandomDouble
                // from r2115 in RandomDouble
                // from r2116 in RandomDouble
                // from r2117 in RandomDouble
                // from r2118 in RandomDouble
                // from r2119 in RandomDouble
                // from r2120 in RandomDouble
                // from r2121 in RandomDouble
                // from r2122 in RandomDouble
                // from r2123 in RandomDouble
                // from r2124 in RandomDouble
                // from r2125 in RandomDouble
                // from r2126 in RandomDouble
                // from r2127 in RandomDouble
                // from r2128 in RandomDouble
                // from r2129 in RandomDouble
                // from r2130 in RandomDouble
                // from r2210 in RandomDouble
                // from r2211 in RandomDouble
                // from r2212 in RandomDouble
                // from r2213 in RandomDouble
                // from r2214 in RandomDouble
                // from r2215 in RandomDouble
                // from r2216 in RandomDouble
                // from r2217 in RandomDouble
                // from r2218 in RandomDouble
                // from r2219 in RandomDouble
                // from r2220 in RandomDouble
                // from r2221 in RandomDouble
                // from r2222 in RandomDouble
                // from r2223 in RandomDouble
                // from r2224 in RandomDouble
                // from r2225 in RandomDouble
                // from r2226 in RandomDouble
                // from r2227 in RandomDouble
                // from r2228 in RandomDouble
                // from r2229 in RandomDouble
                // from r2230 in RandomDouble
                // from r3110 in RandomDouble
                // from r3111 in RandomDouble
                // from r3112 in RandomDouble
                // from r3113 in RandomDouble
                // from r3114 in RandomDouble
                // from r3115 in RandomDouble
                // from r3116 in RandomDouble
                // from r3117 in RandomDouble
                // from r3118 in RandomDouble
                // from r3119 in RandomDouble
                // from r3120 in RandomDouble
                // from r3121 in RandomDouble
                // from r3122 in RandomDouble
                // from r3123 in RandomDouble
                // from r3124 in RandomDouble
                // from r3125 in RandomDouble
                // from r3126 in RandomDouble
                // from r3127 in RandomDouble
                // from r3128 in RandomDouble
                // from r3129 in RandomDouble
                // from r3130 in RandomDouble
                // from r3210 in RandomDouble
                // from r3211 in RandomDouble
                // from r3212 in RandomDouble
                // from r3213 in RandomDouble
                // from r3214 in RandomDouble
                // from r3215 in RandomDouble
                // from r3216 in RandomDouble
                // from r3217 in RandomDouble
                // from r3218 in RandomDouble
                // from r3219 in RandomDouble
                // from r3220 in RandomDouble
                // from r3221 in RandomDouble
                // from r3222 in RandomDouble
                // from r3223 in RandomDouble
                // from r3224 in RandomDouble
                // from r3225 in RandomDouble
                // from r3226 in RandomDouble
                // from r3227 in RandomDouble
                // from r3228 in RandomDouble
                // from r3229 in RandomDouble
                // from r3230 in RandomDouble
                // from r4110 in RandomDouble
                // from r4111 in RandomDouble
                // from r4112 in RandomDouble
                // from r4113 in RandomDouble
                // from r4114 in RandomDouble
                // from r4115 in RandomDouble
                // from r4116 in RandomDouble
                // from r4117 in RandomDouble
                // from r4118 in RandomDouble
                // from r4119 in RandomDouble
                // from r4120 in RandomDouble
                // from r4121 in RandomDouble
                // from r4122 in RandomDouble
                // from r4123 in RandomDouble
                // from r4124 in RandomDouble
                // from r4125 in RandomDouble
                // from r4126 in RandomDouble
                // from r4127 in RandomDouble
                // from r4128 in RandomDouble
                // from r4129 in RandomDouble
                // from r4130 in RandomDouble
                // from r4210 in RandomDouble
                // from r4211 in RandomDouble
                // from r4212 in RandomDouble
                // from r4213 in RandomDouble
                // from r4214 in RandomDouble
                // from r4215 in RandomDouble
                // from r4216 in RandomDouble
                // from r4217 in RandomDouble
                // from r4218 in RandomDouble
                // from r4219 in RandomDouble
                // from r4220 in RandomDouble
                // from r4221 in RandomDouble
                // from r4222 in RandomDouble
                // from r4223 in RandomDouble
                // from r4224 in RandomDouble
                // from r4225 in RandomDouble
                // from r4226 in RandomDouble
                // from r4227 in RandomDouble
                // from r4228 in RandomDouble
                // from r4229 in RandomDouble
                // from r4230 in RandomDouble
                // from r5110 in RandomDouble
                // from r5111 in RandomDouble
                // from r5112 in RandomDouble
                // from r5113 in RandomDouble
                // from r5114 in RandomDouble
                // from r5115 in RandomDouble
                // from r5116 in RandomDouble
                // from r5117 in RandomDouble
                // from r5118 in RandomDouble
                // from r5119 in RandomDouble
                // from r5120 in RandomDouble
                // from r5121 in RandomDouble
                // from r5122 in RandomDouble
                // from r5123 in RandomDouble
                // from r5124 in RandomDouble
                // from r5125 in RandomDouble
                // from r5126 in RandomDouble
                // from r5127 in RandomDouble
                // from r5128 in RandomDouble
                // from r5129 in RandomDouble
                // from r5130 in RandomDouble
                // from r5210 in RandomDouble
                // from r5211 in RandomDouble
                // from r5212 in RandomDouble
                // from r5213 in RandomDouble
                // from r5214 in RandomDouble
                // from r5215 in RandomDouble
                // from r5216 in RandomDouble
                // from r5217 in RandomDouble
                // from r5218 in RandomDouble
                // from r5219 in RandomDouble
                // from r5220 in RandomDouble
                // from r5221 in RandomDouble
                // from r5222 in RandomDouble
                // from r5223 in RandomDouble
                // from r5224 in RandomDouble
                // from r5225 in RandomDouble
                // from r5226 in RandomDouble
                // from r5227 in RandomDouble
                // from r5228 in RandomDouble
                // from r5229 in RandomDouble
                // from r5230 in RandomDouble
                // from r6110 in RandomDouble
                // from r6111 in RandomDouble
                // from r6112 in RandomDouble
                // from r6113 in RandomDouble
                // from r6114 in RandomDouble
                // from r6115 in RandomDouble
                // from r6116 in RandomDouble
                // from r6117 in RandomDouble
                // from r6118 in RandomDouble
                // from r6119 in RandomDouble
                // from r6120 in RandomDouble
                // from r6121 in RandomDouble
                // from r6122 in RandomDouble
                // from r6123 in RandomDouble
                // from r6124 in RandomDouble
                // from r6125 in RandomDouble
                // from r6126 in RandomDouble
                // from r6127 in RandomDouble
                // from r6128 in RandomDouble
                // from r6129 in RandomDouble
                // from r6130 in RandomDouble
                // from r6210 in RandomDouble
                // from r6211 in RandomDouble
                // from r6212 in RandomDouble
                // from r6213 in RandomDouble
                // from r6214 in RandomDouble
                // from r6215 in RandomDouble
                // from r6216 in RandomDouble
                // from r6217 in RandomDouble
                // from r6218 in RandomDouble
                // from r6219 in RandomDouble
                // from r6220 in RandomDouble
                // from r6221 in RandomDouble
                // from r6222 in RandomDouble
                // from r6223 in RandomDouble
                // from r6224 in RandomDouble
                // from r6225 in RandomDouble
                // from r6226 in RandomDouble
                // from r6227 in RandomDouble
                // from r6228 in RandomDouble
                // from r6229 in RandomDouble
                // from r6230 in RandomDouble
                // from r7110 in RandomDouble
                // from r7111 in RandomDouble
                // from r7112 in RandomDouble
                // from r7113 in RandomDouble
                // from r7114 in RandomDouble
                // from r7115 in RandomDouble
                // from r7116 in RandomDouble
                // from r7117 in RandomDouble
                // from r7118 in RandomDouble
                // from r7119 in RandomDouble
                // from r7120 in RandomDouble
                // from r7121 in RandomDouble
                // from r7122 in RandomDouble
                // from r7123 in RandomDouble
                // from r7124 in RandomDouble
                // from r7125 in RandomDouble
                // from r7126 in RandomDouble
                // from r7127 in RandomDouble
                // from r7128 in RandomDouble
                // from r7129 in RandomDouble
                // from r7130 in RandomDouble
                // from r7210 in RandomDouble
                // from r7211 in RandomDouble
                // from r7212 in RandomDouble
                // from r7213 in RandomDouble
                // from r7214 in RandomDouble
                // from r7215 in RandomDouble
                // from r7216 in RandomDouble
                // from r7217 in RandomDouble
                // from r7218 in RandomDouble
                // from r7219 in RandomDouble
                // from r7220 in RandomDouble
                // from r7221 in RandomDouble
                // from r7222 in RandomDouble
                // from r7223 in RandomDouble
                // from r7224 in RandomDouble
                let s = r1  + r2 + r3 + r4 + r5 + r6 + r7 + r8 + r9 + r10 + r11 + r12 + r13 + r14
                from one in One
                from two in AddOne(one)
                from squareBound in SquareSquare(two)
                from g in MultiplyByTwo(s * s * s)
                select squareBound;
            swBldt.Stop();

            var swExec = new Stopwatch();
            swExec.Start();
            var result = query.Result;
            swExec.Stop();

            Console.WriteLine(query.Result);
            Console.WriteLine($"Query bldt time: {swBldt.Elapsed}");
            Console.WriteLine($"Query exec time: {swExec.Elapsed}");
        }
    }
}
