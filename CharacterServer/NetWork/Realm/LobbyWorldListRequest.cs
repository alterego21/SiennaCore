﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Shared;

namespace CharacterServer
{
    [ISerializableAttribute((long)Opcodes.LobbyWorldListRequest)]
    public class LobbyWorldListRequest : ISerializablePacket
    {
        public override void OnRead(RiftClient From)
        {
            Log.Success("WorldList", "Request : In Progress");

            LobbyWorldListResponse Rp = new LobbyWorldListResponse();

            Realm[] Realms = CharacterMgr.Instance.GetRealms();
            foreach (Realm Rm in Realms)
            {
                LobbyWorldEntry Entry = new LobbyWorldEntry();
                Entry.RealmID = Rm.RiftId;
                Entry.PVP = Rm.PVP == 1;
                Entry.Recommended = Rm.Recommended == 1;
                Entry.Population = 0;
                Entry.RP = Rm.RP == 1;
                Entry.Version = Rm.ClientVersion;
                Entry.AddField(16, EPacketFieldType.True, (bool)true);
                Entry.CharactersCount = CharacterMgr.Instance.GetCharactersCount(From.Acct.Id, Rm.RealmId);
                Entry.Language = Rm.Language;
                Rp.Realms.Add(Entry);
            }

            From.SendSerialized(Rp);
        }
    }
}
