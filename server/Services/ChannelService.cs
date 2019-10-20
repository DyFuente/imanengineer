﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TV_App.DataTransferObjects;
using TV_App.Models;

namespace TV_App.Services
{
    public class ChannelService
    {
        private readonly TvAppContext db = new TvAppContext();
        public ChannelDTO GetSingle(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ChannelDTO> GetOffer(long offer_id)
        {
            var channels = db.Channels
                .Include(ch => ch.OfferedChannels)
                .AsNoTracking()
                .ToList();

            return from channel in channels
                   where channel.OfferedChannels.Any(oc => oc.OfferId == offer_id)
                   select new ChannelDTO(channel);
        }

    }
}