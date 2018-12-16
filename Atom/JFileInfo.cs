﻿using mzxrules.Helper;
using mzxrules.OcaLib;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Globalization;

namespace Atom
{
    [DataContract]
    public class JFileInfo
    {
        [DataMember(Order = 1)]
        public string File;

        [DataMember(Order = 2)]
        public string Game;

        [DataMember(Order = 3)]
        public string Version;

        [DataMember(Order = 4)]
        public JFileAddress Rom;

        [DataMember(Order = 5)]
        public JFileAddress Ram;

        [DataMember(Order = 6)]
        public List<JSectionInfo> Sections = new List<JSectionInfo>();

        public JFileInfo() { }

        public JFileInfo(string file, RomVersion version, FileAddress rom, FileAddress ram, JSectionInfo section)
        {
            File = file;
            Game = version.Game.ToString();
            Version = version.ToString();
            Rom = rom;
            Ram = ram;
            Sections.Add(section);
        }
    }

    [DataContract]
    public class JSectionInfo
    {
        [DataMember(Order = 1)]
        public string Name;

        [DataMember(Order = 2)]
        public int Subsection;

        [DataMember(Order = 3)]
        public bool IsCode;

        [DataMember(Order = 4)]
        public JFileAddress Ram;


        public JSectionInfo() { }

        public JSectionInfo(string name, int subsection, bool isCode, FileAddress ram)
        {
            Name = name;
            Subsection = subsection;
            IsCode = isCode;
            Ram = ram;
        }
    }

    [DataContract]
    public class JFileAddress
    {
        [DataMember(Order = 1)]
        public string Start;
        [DataMember(Order = 2)]
        public string End;

        public JFileAddress() { }

        public JFileAddress(FileAddress f)
        {
            Start = f.Start.ToString("X8");
            End = f.End.ToString("X8");
        }

        public static implicit operator JFileAddress(FileAddress v)
        {
            return new JFileAddress(v);
        }

        public FileAddress Convert()
        {
            return new FileAddress(long.Parse(Start, NumberStyles.HexNumber), long.Parse(End, NumberStyles.HexNumber));
        }
    }

}