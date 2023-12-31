using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class TEST{
	static void Main(){
		Sol mySol =new Sol();
		mySol.Solve();
	}
}

class Sol{
	
	const long mod = (long) 1e9 + 7;
	
	public void Solve(){
		
		List<int>[] E = new List<int>[N];
		for(int i=0;i<N;i++) E[i] = new List<int>();
		for(int i=0;i<M;i++){
			E[U[i]].Add(i);
			E[V[i]].Add(i);
		}
		
		long Inf = (long) 1e18;
		long[][] min = new long[2][];
		for(int i=0;i<2;i++){
			min[i] = new long[M];
			for(int j=0;j<N;j++) min[i][j] = Inf;
		}
		
		int[] strt = new int[]{S, T};
		for(int t=0;t<2;t++){
			var SH = new SkewHeap<Pair>();
			bool[] used = new bool[N];
			SH.Push(new Pair(strt[t],0));
			min[t][strt[t]] = 0;
			while(SH.Count > 0){
				
				var p = SH.Top; SH.Pop();
				var now = p.Pos;
				var cost = p.Cost;
				if(used[now]) continue;
				used[now] = true;
				min[t][now] = cost;
				foreach(var ne in E[now]){
					long nc = cost + D[ne];
					int nv = U[ne] == now ? V[ne] : U[ne];
					if(min[t][nv] > nc){
						min[t][nv] = nc;
						SH.Push(new Pair(nv, nc));
					}
				}
			}
		}
		
		long[][] comb = new long[2][];
		HashSet<int> minedge = new HashSet<int>();
		for(int t=0;t<2;t++){
			int fr = strt[t];
			int to = strt[t^1];
			List<Pair> L = new List<Pair>();
			for(int i=0;i<N;i++){
				L.Add(new Pair(i,min[t][i]));
			}
			L.Sort((p,q) => p.Cost.CompareTo(q.Cost));
			
			comb[t] = new long[N];
			comb[t][fr] = 1;
			long dmin = min[t][to];
			
			foreach(var pp in L){
				int now = pp.Pos;
				if(min[t][now] >= dmin) break;
				foreach(var ne in E[now]){
					long cost = D[ne];
					int ttt = U[ne] == now ? V[ne] : U[ne];
					if(min[t^1][ttt] + cost == min[t^1][now]){
						minedge.Add(ne);
						comb[t][ttt] += comb[t][now]; if(comb[t][ttt] >= mod) comb[t][ttt] -= mod;
					}
				}
			}
		}
		
		long dmax = min[0][T];
		
		long total = (comb[0][T] * comb[1][S]) % mod;
		bool[] uused = new bool[N];
		long remv = 0;
		for(int i=0;i<N;i++){
			if(min[0][i] == dmax - min[0][i]){
				long c = (comb[0][i] * comb[1][i] % mod) * (comb[1][i] * comb[0][i] % mod) % mod ;
				remv += c; if(remv >= mod) remv -= mod;
			}
		}
		//Console.WriteLine(total);
		//Console.WriteLine(remv);
		
		foreach(var e in minedge){
			int u = U[e];
			int v = V[e];
			long di = D[e];
			
			if(min[0][u] < min[0][v]){
				if(2 * min[0][u] < dmax && 2 * min[0][v] > dmax ){
					long c = (comb[0][u] * comb[1][v] % mod) * (comb[1][v] * comb[0][u] % mod) % mod ;
					remv += c; if(remv >= mod) remv -= mod;
				}
			} else if(min[0][u] > min[0][v]){
				if(2 * min[0][v] < dmax && 2 * min[0][u] > dmax ){
					long c = (comb[0][v] * comb[1][u] % mod ) * (comb[1][u] * comb[0][v] % mod ) % mod;
					remv += c; if(remv >= mod) remv -= mod;
				}
			}
		}
		
		long ans = (total + mod - remv) % mod;
		Console.WriteLine(ans);
		
	}
	int N,M;
	int S,T;
	int[] U,V;
	long[] D;
	
	public Sol(){
		var d = ria();
		N = d[0]; M = d[1];
		d = ria();
		S = d[0] - 1; T = d[1] - 1;
		U = new int[M];
		V = new int[M];
		D = new long[M];
		for(int i=0;i<M;i++){
			d = ria();
			U[i] = d[0] - 1;
			V[i] = d[1] - 1;
			D[i] = d[2];
			
		}
		
		
		
	}

	static String rs(){return Console.ReadLine();}
	static int ri(){return int.Parse(Console.ReadLine());}
	static long rl(){return long.Parse(Console.ReadLine());}
	static double rd(){return double.Parse(Console.ReadLine());}
	static String[] rsa(char sep=' '){return Console.ReadLine().Split(sep);}
	static int[] ria(char sep=' '){return Array.ConvertAll(Console.ReadLine().Split(sep),e=>int.Parse(e));}
	static long[] rla(char sep=' '){return Array.ConvertAll(Console.ReadLine().Split(sep),e=>long.Parse(e));}
	static double[] rda(char sep=' '){return Array.ConvertAll(Console.ReadLine().Split(sep),e=>double.Parse(e));}
}


class Pair : IComparable<Pair> {
	public int Pos;
	public long Cost;
	public Pair(int p, long c) {
		Pos = p; Cost = c;
	}
	public int CompareTo(Pair t) {
		//return this.Cost > t.Cost ? -1 : this.Cost < t.Cost ? 1 : 0;
		return this.Cost > t.Cost ? 1 : this.Cost < t.Cost ? -1 : 0;
	}
}


class SkewHeap<T> where T:IComparable<T>{
	public int Count{
		get{return cnt;}
		private set{cnt=value;}
	}
	
	public SkewHeap(){
		root=null;
		this.Count=0;
	}
	
	public void Push(T v){
		NodeSH<T> p=new NodeSH<T>(v);
		root=NodeSH<T>.Meld(root,p);
		this.Count++;
	}
	
	public void Pop(){
		if(root==null)return;
		root=NodeSH<T>.Meld(root.L,root.R);
		this.Count--;
	}
	
	public T Top{
		get{return root.Val;}
	}
	
	int cnt;
	NodeSH<T> root;
	
	class NodeSH<S> where S : IComparable<S> {
		public NodeSH<S> L, R;
		public S Val;

		public NodeSH(S v){
			Val = v;
			L = null; R = null;
		}
		public static NodeSH<S> Meld(NodeSH<S> a, NodeSH<S> b){
			if(a == null)return b;
			if (b == null) return a;
			if (a.Val.CompareTo(b.Val) > 0) swap(ref a, ref b);
			a.R = Meld(a.R, b);
			swap(ref a.L, ref a.R);
			return a;
		}

		static void swap<U>(ref U x, ref U y) {
			U t = x; x = y; y = t;
		}
	}
}