﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaleTabs
{
    class Program
    {
        enum Note
        {
            A = 0,
            Asharp=1,
            B=2,
            C=3,
            Csharp=4,
            D=5,
            Dsharp=6,
            E=7,
            F=8,
            Fsharp=9,
            G=10,
            Gsharp=11
        }
        //I'm sure if this wasn't a one off, there'd be a better way to do this.. 
        int MajorScale(Note root,Note n)
        {
            var ni = (int)n;
            var rooti = (int)root;
            var list = new List<Note>();

            list.Add(root);
            var tmp = Wholestep(root);
            list.Add(tmp);
            tmp = Wholestep(tmp);
            list.Add(tmp);
            tmp = Halfstep(tmp);
            list.Add(tmp);
            tmp = Wholestep(tmp);
            list.Add(tmp);
            tmp = Wholestep(tmp);
            list.Add(tmp);
            tmp = Wholestep(tmp);
            list.Add(tmp);
            //tmp = Halfstep(tmp);
            //list.Add(tmp);
            if(list.Contains(n))
            {
                return list.IndexOf(n);
            }
            return -1;
        }

        int MinorScale(Note root, Note n)
        {
            var ni = (int)n;
            var rooti = (int)root;
            var list = new List<Note>();

            list.Add(root);
            var tmp = Wholestep(root);
            list.Add(tmp);
            tmp = Halfstep(tmp);
            list.Add(tmp);
            tmp = Wholestep(tmp);
            list.Add(tmp);
            tmp = Wholestep(tmp);
            list.Add(tmp);
            tmp = Halfstep(tmp);
            list.Add(tmp);
            tmp = Wholestep(tmp);
            list.Add(tmp);
            //tmp = Wholestep(tmp); //octave
            //list.Add(tmp);
            if (list.Contains(n))
            {
                return list.IndexOf(n);
            }
            return -1;
        }

        Note Halfstep(Note n)
        {
            var ni = (int)n;
            ni++;
            return (Note)(ni % 12);
        }
        Note Wholestep(Note n)
        {
            var ni = (int)n;
            ni+=2;
            return (Note)(ni % 12);
        }
        static void Main(string[] args)
        {
            var m = new Program();
            m.Stuff(args);
        }
        void Stuff(string[] args)
        {
            int fretmax = 22;
            List<List<Note>> Strings = new List<List<Note>>();
            Strings.Add(GenerateString(Note.E, fretmax));
            Strings.Add(GenerateString(Note.B, fretmax));
            Strings.Add(GenerateString(Note.G, fretmax));
            Strings.Add(GenerateString(Note.D, fretmax));
            Strings.Add(GenerateString(Note.A, fretmax));
            Strings.Add(GenerateString(Note.E, fretmax));

            var l=MarkFrets(Strings[0], Note.C, MajorScale);
            ;

        }
        void PrintFrets(List<Note> str, List<int> marks, char notation)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var mark in marks)
            {
                sb.Append("|");
                if(mark == -1)
                {
                    sb.Append("--");
                }
                else
                {
                    sb.Append(notation);
                    sb.Append(str);
                }
                sb.Append("|");
            }
        }
        //returns list with the index corresponding to fret number and value being the "th" of the scale (or -1 for not in it)
        List<int> MarkFrets(List<Note> str, Note root, Func<Note, Note, int> scale)
        {
            var list=new List<int>();
            for(int i=0;i<str.Count;i++)
            {
                list.Add(scale(root, str[i]));
            }
            return list;
        }
        List<Note> GenerateString(Note root, int frets)
        {
            var list = new List<Note>();
            list.Add(root);
            var last=root;
            for(int i=1;i<frets+1;i++)
            {
                last=Halfstep(last);
                list.Add(last);
            }
            return list;
        }



    }
}
