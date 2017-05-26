﻿using BL.Servers.CoC.Extensions.Binary;
using BL.Servers.CoC.Logic;
using BL.Servers.CoC.Logic.Enums;
using BL.Servers.CoC.Logic.Structure;

namespace BL.Servers.CoC.Packets.Commands.Client
{
    internal class SpeedUp_Construction : Command
    {
        internal int BuildingId;

        public SpeedUp_Construction(Reader reader, Device client, int id) : base(reader, client, id)
        {
        }
        internal override void Decode()
        {
            this.BuildingId = this.Reader.ReadInt32();
            this.Reader.ReadInt32();
        }

        internal override void Process()
        {
            var go =  this.Device.Player.Avatar.Village_Mode == Village_Mode.NORMAL_VILLAGE ? this.Device.Player.GameObjectManager.GetGameObjectByID(BuildingId) : this.Device.Player.GameObjectManager.GetBuilderVillageGameObjectByID(BuildingId);

            if (go != null)
            {
                if (go.ClassId == 0 || go.ClassId == 4 || go.ClassId == 7 || go.ClassId == 11)
                {
                    ((ConstructionItem)go).SpeedUpConstruction();
                }
            }
        }
    }
}
