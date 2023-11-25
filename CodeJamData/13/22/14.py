#!/usr/bin/env python2.7
#coding=UTF-8

# Copyright © 2009-2013 by T. Chan.

from __future__ import division,with_statement#,absolute_import,print_function
import __builtin__ as builtin,sys,os,os.path,re,time,hashlib,base64,StringIO as io,cPickle as pickle
import operator,array,itertools,bisect,collections,heapq
import pprint,pdb,traceback,warnings
from pdb import set_trace as debug
from math import hypot,pi,sin,cos,tan,sqrt,floor,ceil,asin,fsum
from itertools import islice,izip,imap
from collections import namedtuple,deque

from fractions import Fraction as Q
#def Q(a,b): return a/b

#CACHE_ = [None]
#def gen(cachefile,ts):
#	global CACHE_
#	if os.path.exists(cachefile):
#		with open(cachefile,'rb') as f: CACHE_ = (pickle.load(f))
#		ts('g')
#		return
#	CACHE_ = ...
#	with open(cachefile,'wb') as f: pickle.dump(CACHE_,f,-1)
#	ts('c')

def f(n):
	n = 2*n+1
	return n*(n+1)//2

def bsum(n,r):
	sum = 1
	coeff = 1
	for i in xrange(r):
		coeff *= n-i
		assert coeff%(i+1) == 0
		coeff //= i+1
		sum += coeff
	return sum

def process2(N,X,Y):
	#if (N,X,Y) == (4,0,2): debug()
	X = abs(X)
	xx = (X+Y)//2
	if f(xx) <= N:
		return 1.0
	if  N <= f(xx-1) or X == 0:
		return 0.0
	assert f(xx-1) < N < f(xx)
	extra = N-f(xx-1)
	threshold = 2*xx+Y+1
	if extra >= threshold:
		return 1.0
	return 1-bsum(extra,Y)/(2**extra)

def process(f_, out):
	T_, = map(int,f_.readline().strip().split())
	for X_ in range(1,T_+1):
		N,X,Y = map(int,f_.readline().strip().split())
		output = process2(N,X,Y)
		out.write('Case #%d: %s\n' % (X_,output))
		out.flush()

TEST_DATA=(r''' 7
1 0 0
1 0 2
3 0 0
3 2 0
3 1 1
4 1 1
4 0 2
Case #1: 1.0
Case #2: 0.0
Case #3: 1.0
Case #4: 0.75
Case #5: 0.25
Case #6: 0.5
Case #7: 0.0
 ''',)#r'''  ''')

# Running
def pmfunc(func):
	def wrapped_func(*args,**kwargs):
		try: return func(*args,**kwargs)
		except: traceback.print_exc(); pdb.post_mortem(); raise
	return wrapped_func
if __debug__: process=pmfunc(process)

def process_test(d):
	f_,out = io.StringIO(d),io.StringIO()
	process(f_,out)
	return out.getvalue()

def process_file(fn,auto=False):
	for ext in ('.in', '.in.txt', ''):
		if fn.endswith(ext): base = fn[:-len(ext)] if ext else fn; break
	i = 0
	while 1:
		path = '%s.out%d.txt'%(base,i); path2 = 'broken-'+path
		p1,p2 = os.path.exists(path), os.path.exists(path2)
		if not (p1 or p2): break
		if auto and p1: print "! %s exists"%(path if p1 else path2); return
		i += 1
	print ">> %s"%path
	success = None
	try:
		with open(fn,'rb') as f_,open(path,'wb') as out: process(f_,out)
		success = True
	finally:
		if not success: os.rename(path,path2)
	return success

def main():
	def ts(prefix='>',delta=True,old=[None]):
		t = time.time()
		diff, old[0] = (delta and (old[0] is not None)) and ' d%.6f'%(t - old[0]) or '', t
		print '%s %s %.6f%s'%(prefix,time.strftime('%F %T %z',time.gmtime(t)),t,diff)

	ts(' ',delta=False)

	qid = rundir = testcache = None
	mydir,myfile = os.path.split(os.path.join(os.path.curdir,__file__))
	assert os.path.abspath(mydir) == os.path.abspath(os.path.curdir)
	if myfile.endswith('.py'):
		qid,rundir,t,myhash = myfile[:-3].upper(), os.path.join(mydir,'runs'), time.time(), hashlib.sha256()
		if not os.path.isdir(rundir): os.makedirs(rundir)
		runfile = os.path.join(rundir, '%s_%s.%06dz.py'%(qid,time.strftime('%F-%H%M%S',time.gmtime(t)),round(t%1*1e6)))
		assert not os.path.exists(runfile)
		with open(__file__,'rb') as fin, open(runfile,'wb') as fout:
			d = fin.readline()+fin.readline(); fout.write(d); myhash.update(d)
			fout.write('\n# RUN at %s %.6f\n# cmdline = %r\n\n'%(time.strftime('%F %T %z',time.gmtime(t)),t,sys.argv))
			d = fin.read(); fout.write(d); myhash.update(d)
		testcache = os.path.join(rundir,'%s_%s.passed'%(qid,base64.b32encode(myhash.digest()).rstrip('=')))
		del fin, fout, t, runfile, myhash

	if 'gen' in globals(): gen(os.path.join(mydir,myfile+'.pickle'), ts)
	l = sys.argv[1:]
	auto=False
	if not l:
		if not (testcache and os.path.exists(testcache)):
			def td(d):
				if isinstance(d,str): d=d.split('Case #1:',1); return d[0].strip(), 'Case #1:' + d[1].rstrip() + '\n'
				return d
			for test_data in TEST_DATA:
				if not test_data.strip(): print >>sys.stderr, '! Empty test case.'; return
				test_input,expected_output=td(test_data)
				my_output = process_test(test_input)
				if my_output != expected_output: print >>sys.stderr, "!!! Wrong output."; print >>sys.stderr, my_output; return
				ts('v')
			if testcache: open(testcache,'wb').close()
		if qid:
			expr = re.compile(r'\A%s\-(?:large|small-attempt[0-9]|(?:large|small)\-practice)\.in(?:\.txt)?\Z'%qid)
			auto=True
			l = list(f for f in os.listdir(mydir) if expr.match(f))
	for x in l:
		ts('.',delta=False)
		print '<< %s'%x
		if x == '-': process(sys.stdin,sys.stdout)
		else: process_file(x,auto=auto)
		ts('>')

if __name__ == '__main__':
	main()
