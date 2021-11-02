using OMDBAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OMDBAPI.Business.Interfaces
{
    public interface IOmdbService
    {
        Task<OmdbResponse> GetOmdbResponseAsync(string title);
    }
}
