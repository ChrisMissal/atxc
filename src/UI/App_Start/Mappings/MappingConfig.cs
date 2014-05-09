﻿namespace UI.Mappings
{
    using AutoMapper;
    using StructureMap;

    public class MappingConfig
    {
        public static void Register(Container container)
        {
            var mappingProfiles = container.GetAllInstances<Profile>();

            foreach (var profile in mappingProfiles)
            {
                Mapper.AddProfile(profile);
            }
        }
    }
}