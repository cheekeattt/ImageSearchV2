﻿using ImageSearchV2.Models.PixaBay.Request;
using ImageSearchV2.Models.PixaBay.Response;

namespace ImageSearchV2.Interfaces
{
    public interface IPixaBaySourceProvider
    {
        public Task<PixaBayResponse> SearchImage(PixaBayRequest request);
    }
}
