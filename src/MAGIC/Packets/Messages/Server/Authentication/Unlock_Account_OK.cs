﻿using System;
using System.Collections.Generic;
using System.Linq;
using CRepublic.Magic.Extensions;
using CRepublic.Magic.Extensions.List;
using CRepublic.Magic.External.Sodium;
using CRepublic.Magic.Logic;

namespace CRepublic.Magic.Packets.Messages.Server.Authentication
{
    internal class Unlock_Account_OK : Message
    {
        internal Player Account;
        internal Unlock_Account_OK(Device Device) : base(Device)
        {
            this.Identifier = 20132;
        }

        internal override void Encode()
        {
            this.Data.AddLong(this.Account.UserId);
            this.Data.AddString(this.Account.Token);
        }

        internal override void EncryptPepper()
        {
            this.Device.Keys.RNonce.Increment();

            this.Data = new List<byte>(Sodium
                .Encrypt(this.Data.ToArray(), this.Device.Keys.RNonce, this.Device.Keys.PublicKey)
                .Skip(16)
                .ToArray());

            this.Length = (ushort)this.Data.Count;
        }
    }
}