#pragma warning disable
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.Collections;
using static System.Math;
using static System.Console;

class E { static void Main() => new J(); }
class J
{
	const int Mod = 1000000007;
	int F() => int.Parse(ReadLine());
	int[] G() => ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
	public J()
	{
		SetOut(new StreamWriter(OpenStandardOutput()) { AutoFlush = false });
		Solve();
		Out.Flush();
	}
	int N, M, K;
	int[] A, B;
	RandomSFMT rand = new RandomSFMT();
	void Solve()
	{
		var I = G();
		N = I[0]; M = I[1]; K = I[2];
		A = new int[M];
		B = new int[M];
		for (var i = 0; i < M; i++)
		{
			I = G();
			A[i] = I[0]; B[i] = I[1];
		}
		//var t = DateTime.Now;
		//WriteLine(t);
		if (M == 0) WriteLine(1);
		else if (N == 2) WriteLine(0);
		else
		{
			a = new int[N];
			var c = 0;
			var M = 1000000;
			for (var i = 0; i < M; i++) if (Safe()) c++;
			WriteLine(c / (double)M);
		}
		//var s = DateTime.Now;
		//WriteLine(s);
		//WriteLine(s - t);
	}
	int[] a;
	bool Safe()
	{
		for (var i = 0; i < N; i++) a[i] = i;
		for (var k = 0; k < K; k++)
		{
			var i = rand.Next(N);
			var j = rand.Next(N - 1);
			if (j >= i) j++;
			var t = a[i];
			a[i] = a[j];
			a[j] = t;
		}
		for (var i = 0; i < M; i++)
		{
			var x = a[A[i]];
			var y = a[B[i]];
			var z = Abs(x - y);
			if (z == 1 || z == N - 1) return false;
		}
		return true;
	}
	long GCD(long a, long b)
	{
		var n = (ulong)Abs(a); var m = (ulong)Abs(b);
		if (n == 0) return (long)m; if (m == 0) return (long)n;
		int zm = 0, zn = 0;
		while ((n & 1) == 0) { n >>= 1; zn++; }
		while ((m & 1) == 0) { m >>= 1; zm++; }
		while (m != n)
		{
			if (m > n) { m -= n; while ((m & 1) == 0) m >>= 1; }
			else { n -= m; while ((n & 1) == 0) n >>= 1; }
		}
		return (long)n << Min(zm, zn);
	}
}
class RandomSFMT : Random
{
	int index, coin_bits, byte_pos, range, shift;
	uint coin_save, byte_save, bse;
	protected uint[] x = new uint[40];
	static uint[] ParityData = { 0x00000001U, 0x00000000U, 0x00000000U, 0x20000000U };
	public virtual void GenRandAll()
	{
		int a = 0, b = 28, c = 32, d = 36; uint y; var p = x;
		do
		{
			y = p[a + 3] ^ (p[a + 3] << 24) ^ (p[a + 2] >> 8) ^ ((p[b + 3] >> 5) & 0xb5ffff7fU);
			p[a + 3] = y ^ (p[c + 3] >> 8) ^ (p[d + 3] << 14);
			y = p[a + 2] ^ (p[a + 2] << 24) ^ (p[a + 1] >> 8) ^ ((p[b + 2] >> 5) & 0xaff3ef3fU);
			p[a + 2] = y ^ ((p[c + 2] >> 8) | (p[c + 3] << 24)) ^ (p[d + 2] << 14);
			y = p[a + 1] ^ (p[a + 1] << 24) ^ (p[a] >> 8) ^ ((p[b + 1] >> 5) & 0x7fefcfffU);
			p[a + 1] = y ^ ((p[c + 1] >> 8) | (p[c + 2] << 24)) ^ (p[d + 1] << 14);
			y = p[a] ^ (p[a] << 24) ^ ((p[b] >> 5) & 0xf7fefffdU);
			p[a] = y ^ ((p[c] >> 8) | (p[c + 1] << 24)) ^ (p[d] << 14);
			c = d; d = a; a += 4; b += 4;
			if (b == 40) b = 0;
		} while (a != 40);
	}
	void PeriodCertification()
	{
		uint work, inner = 0; int i, j;
		index = 40; range = 0; coin_bits = 0; byte_pos = 0;
		for (i = 0; i < 4; i++) inner ^= x[i] & ParityData[i];
		for (i = 16; i > 0; i >>= 1) inner ^= inner >> i;
		inner &= 1;
		if (inner == 1) return;
		for (i = 0; i < 4; i++) for (j = 0, work = 1; j < 32; j++, work <<= 1) if ((work & ParityData[i]) != 0) { x[i] ^= work; return; }
	}
	public void InitMt(uint s)
	{
		unchecked
		{
			x[0] = s;
			for (uint p = 1; p < 40; p++) x[p] = s = 1812433253 * (s ^ (s >> 30)) + p;
			PeriodCertification();
		}
	}
	public RandomSFMT(uint s) { InitMt(s); }
	public void InitMtEx(uint[] init_key)
	{
		uint r, i, j, c, key_len = (uint)init_key.Length;
		unchecked
		{
			for (i = 0; i < 40; i++) x[i] = 0x8b8b8b8b;
			if (key_len + 1 > 40) c = key_len + 1; else c = 40;
			r = x[0] ^ x[17] ^ x[39]; r = (r ^ (r >> 27)) * 1664525;
			x[17] += r; r += key_len; x[22] += r; x[0] = r; c--;
			for (i = 1, j = 0; j < c && j < key_len; j++)
			{
				r = x[i] ^ x[(i + 17) % 40] ^ x[(i + 39) % 40];
				r = (r ^ (r >> 27)) * 1664525; x[(i + 17) % 40] += r;
				r += init_key[j] + i; x[(i + 22) % 40] += r;
				x[i] = r; i = (i + 1) % 40;
			}
			for (; j < c; j++)
			{
				r = x[i] ^ x[(i + 17) % 40] ^ x[(i + 39) % 40];
				r = (r ^ (r >> 27)) * 1664525; x[(i + 17) % 40] += r; r += i;
				x[(i + 22) % 40] += r; x[i] = r; i = (i + 1) % 40;
			}
			for (j = 0; j < 40; j++)
			{
				r = x[i] + x[(i + 17) % 40] + x[(i + 39) % 40];
				r = (r ^ (r >> 27)) * 1566083941; x[(i + 17) % 40] ^= r;
				r -= i; x[(i + 22) % 40] ^= r; x[i] = r; i = (i + 1) % 40;
			}
			PeriodCertification();
		}
	}
	public RandomSFMT(uint[] init_key) { InitMtEx(init_key); }
	public RandomSFMT() : this((uint)(DateTime.Now.Ticks & 0xffffffff)) { }
	public uint NextMt() { if (index == 40) { GenRandAll(); index = 0; } return x[index++]; }
	public int NextInt(int n) => (int)(n * (1.0 / 4294967296.0) * NextMt());
	public double NextUnif() { uint z = NextMt() >> 11, y = NextMt(); return (y * 2097152.0 + z) * (1.0 / 9007199254740992.0); }
	public int NextBit() { if (--coin_bits == -1) { coin_bits = 31; return (int)(coin_save = NextMt()) & 1; } else return (int)(coin_save >>= 1) & 1; }
	public int NextByte() { if (--byte_pos == -1) { byte_pos = 3; return (int)(byte_save = NextMt()) & 255; } else return (int)(byte_save >>= 8) & 255; }
	public override int Next(int maxValue) => Next(0, maxValue);
	protected override double Sample() => NextUnif();
	public override double NextDouble() => NextUnif();
	public override int Next() => 1 + NextIntEx(int.MaxValue);
	public override void NextBytes(byte[] buffer) { for (var i = 0; i < buffer.Length; i++) buffer[i] = (byte)NextByte(); }
	public override int Next(int min, int max) => min + NextIntEx(max - min);
	public int NextIntEx(int range_)
	{
		uint y_, base_, remain_; int shift_;
		if (range_ <= 0) return 0;
		if (range_ != range)
		{
			bse = (uint)(range = range_);
			for (shift = 0; bse <= (1UL << 30); shift++) bse <<= 1;
		}
		while (true)
		{
			y_ = NextMt() >> 1;
			if (y_ < bse) return (int)(y_ >> shift);
			base_ = bse; shift_ = shift; y_ -= base_;
			remain_ = (1U << 31) - base_;
			for (; remain_ >= (uint)range_; remain_ -= base_)
			{
				for (; base_ > remain_; base_ >>= 1) shift_--;
				if (y_ < base_) return (int)(y_ >> shift_);
				else y_ -= base_;
			}
		}
	}
}