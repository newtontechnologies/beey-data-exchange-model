﻿using System;

namespace Backend.Serialization
{

    /// <summary>
    /// json ignore only for WebJsonSerializer. (to enable saving EntityBase types into elastic)
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class JsonIgnoreWebAttribute : Attribute
    {
    }
}
