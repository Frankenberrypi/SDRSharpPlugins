﻿using System;

namespace SDRSharp.EasyScanner
{
    public class MemoryInfoEventArgs: EventArgs
    {
        private readonly MemoryEntry _memoryEntry;

        public MemoryInfoEventArgs(MemoryEntry entry)
        {
            _memoryEntry = entry;
        }

        public MemoryEntry MemoryEntry
        {
            get
            {
                return _memoryEntry;
            }
        }
    }
}
