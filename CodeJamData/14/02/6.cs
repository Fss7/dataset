﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJam
{
    class Program
    {
        static void Main(string[] args)
        {
            using (CodeJamIO io = new CodeJamIO("in.txt", "out.txt"))
            {
                Program p = new Program(io); ;
                p.Go();
            }
        }

        private CodeJamIO m_io = null;
        public Program(CodeJamIO io)
        {
            m_io = io;
        }

        private void Go()
        {
            int T = m_io.ReadInt();
            for (int t = 0; t < T; t++)
            {
                double C_FarmCost = m_io.ReadDouble();
                double F_FarmBonus = m_io.ReadDouble();
                double X_Goal = m_io.ReadDouble();
                double currentRate = 2.0; //c/s
                double currentTime = 0.0; //s
                double currentCookies = 0.0; //c

                for (; ; )
                {
                    double timeToWinWithCurrentFarms = (X_Goal-currentCookies) / currentRate;
                    double timeUntilAffordNextFarm = (C_FarmCost - currentCookies) / currentRate;
                    double timeToWinWithAnotherFarm = timeUntilAffordNextFarm + X_Goal / (currentRate + F_FarmBonus);
                    if (timeToWinWithCurrentFarms < timeToWinWithAnotherFarm)
                    {
                        m_io.WriteCase(currentTime + timeToWinWithCurrentFarms);
                        break;
                    }
                    else
                    {
                        currentTime += timeUntilAffordNextFarm;
                        currentCookies = 0.0;
                        currentRate += F_FarmBonus;
                    }
                }
            }
        }
    }

    #region IO Class

    class CodeJamIO : IDisposable
    {
        private int m_case = 0;
        private string m_currentLine;
        private StreamReader m_reader;
        private StreamWriter m_writer;

        public CodeJamIO(string infile, string outfile)
        {
            m_reader = new StreamReader(infile);
            m_writer = new StreamWriter(outfile);
        }

        public void WriteCase(string result)
        {
            ++m_case;
            m_writer.WriteLine("Case #{0}: {1}", m_case, result);
            Console.WriteLine("Case #{0}: {1}", m_case, result);
        }
        public void WriteCase(long result)
        {
            WriteCase(result.ToString());
        }
        public void WriteCase(int result)
        {
            WriteCase(result.ToString());
        }

        public void WriteCase(double result)
        {
            WriteCase(result.ToString("F7"));
        }

        public long ReadLong()
        {
            return long.Parse(ReadWord());
        }

        public int ReadInt()
        {
            return int.Parse(ReadWord());
        }

        public double ReadDouble()
        {
            return Double.Parse(ReadWord());
        }

        public string ReadLine()
        {
            if (String.IsNullOrWhiteSpace(m_currentLine))
            {
                m_currentLine = m_reader.ReadLine();
                if (m_currentLine == null)
                    throw new Exception("end of file");
            }
            string ret = m_currentLine;
            m_currentLine = null;
            return ret;
        }

        private static char[] whitespace = new char[] { ' ', '\t', '\n', '\r' };

        public string ReadWord()
        {

            string ret;
            int i;
            for (i = 0; string.IsNullOrWhiteSpace(m_currentLine) && i < 1000; i++)
            {
                m_currentLine = m_reader.ReadLine();
            }
            if (i >= 1000)
                throw new Exception("Too many bad reads");
            m_currentLine = m_currentLine.TrimStart(whitespace);
            int positionOfNextSpace = m_currentLine.IndexOfAny(whitespace);
            if (positionOfNextSpace < 0)
            {
                ret = m_currentLine;
                m_currentLine = null;

            }
            else
            {
                ret = m_currentLine.Substring(0, positionOfNextSpace);
                m_currentLine = m_currentLine.Substring(positionOfNextSpace);
            }

            return ret;
        }

        private bool m_disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!m_disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.
                    m_writer.Flush();
                    m_writer.Close();
                    m_writer.Dispose();
                }

                m_disposed = true;
            }
        }
    }
    #endregion IO Class
}