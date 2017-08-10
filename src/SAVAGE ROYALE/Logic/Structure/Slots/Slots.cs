﻿using System;
using System.Collections.Generic;
using CRepublic.Royale.Logic.Structure.Slots.Items;

namespace CRepublic.Royale.Logic.Structure.Slots
{
    internal class Slots : List<Slot>, ICloneable
    {
        internal Slots Clone()
        {
            return this.MemberwiseClone() as Slots;
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }
    }
}