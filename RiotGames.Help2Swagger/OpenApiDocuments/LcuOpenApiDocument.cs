﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;

namespace RiotGames.Help2Swagger
{
    internal class LcuOpenApiDocument : OpenApiDocument
    {
        public LcuOpenApiDocument()
        {
            Info = new OpenApiInfo
            {
                Title = "League Client Update",
                Version = "1.0.0-magisteriis",
                Contact = new OpenApiContact
                {
                    Name = "Mikael Dúi Bolinder (DevOps Activist)",
                    Url = new Uri("https://discord.gg/riotgamesdevrel")
                },
                Description = "Auto-generated from the LCU help files.",
                License = new OpenApiLicense
                {
                    Name = "The Unlicense"
                }
            };

            Paths = new OpenApiPaths();

            Components = new OpenApiComponents
            {
                SecuritySchemes =
                {
                    {
                        "basicAuth", new OpenApiSecurityScheme
                        {
                            Type = SecuritySchemeType.Http,
                            Scheme = "basic",
                            Description =
                                "Username: riot. Password randomly generated on LCU start, it's NOT your account password."
                        }
                    }
                }
            };

            SecurityRequirements.Add(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "basicAuth"}
                    },
                    new List<string>()
                }
            });

            Servers.Add(new OpenApiServer
            {
                Description = "YOUR local instance of LCU.",
                Url = "https://127.0.0.1:{port}",
                Variables =
                {
                    {
                        "port", new OpenApiServerVariable()
                        {
                            Description = "The port this LCU instance is running on. Changes every restart."
                        }
                    }
                }
            });
        }
    }
}
