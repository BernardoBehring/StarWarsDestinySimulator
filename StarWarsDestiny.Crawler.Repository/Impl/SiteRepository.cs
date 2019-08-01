﻿using StarWarsDestiny.Common.Repository.Impl;
using StarWarsDestiny.Crawler.Model;
using StarWarsDestiny.Crawler.Repository.Interfaces;
using StarWarsDestiny.Model;

namespace StarWarsDestiny.Crawler.Repository.Impl
{
    public class SiteRepository : ReadWriteRepository<Site, EntityId>, ISiteRepository
    {
    }
}
