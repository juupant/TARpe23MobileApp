using Models;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.WebRequestMethods;

namespace Services
{
    internal class PlanetsService
    {
        private static List<Planet> planets = new List<Planet>
        {
            new Planet()
            {
                Name = "Mercury",
                Subtitle = "The smallest planet",
                HeroImage = "mercury.png",
                Description = "Mercury is the first planet from the Sun and the smallest in the Solar System. In English, it is named after the ancient Roman god Mercurius (Mercury), god of commerce and communication, and the messenger of the gods. Mercury is classified as a terrestrial planet, with roughly the same surface gravity as Mars. The surface of Mercury is heavily cratered, as a result of countless impact events that have accumulated over billions of years. Its largest crater, Caloris Planitia, has a diameter of 1,550 km (960 mi), which is about one-third the diameter of the planet (4,880 km or 3,030 mi). Similarly to the Earth's Moon, Mercury's surface displays an expansive rupes system generated from thrust faults and bright ray systems formed by impact event remnants.",
                AccentColorStart = Color.FromArgb("#353535"),
                AccentColorEnd = Color.FromArgb("#8D9098"),
                Images = new List<string>
                {
                    "https://cdn.theatlantic.com/thumbor/D15rQggf6357X1-u6VpTD2N1yQE=/0x27:1041x613/976x549/media/img/mt/2017/04/MercuryImage/original.jpg",
                    "https://upload.wikimedia.org/wikipedia/commons/4/4a/Mercury_in_true_color.jpg",
                    "https://www.usatoday.com/gcdn/authoring/authoring-images/2024/11/25/USAT/76567098007-usatgraphics-mercury-retrograde-24-topper.png?crop=3470,1952,x170,y1&width=3200&height=1801&format=pjpg&auto=webp"
                }
            },
            new Planet()
            {
                Name = "Venus",
                Subtitle = "The pressure cooker",
                HeroImage = "venus.png",
                Description = "Venus is the second planet from the Sun. It is a terrestrial planet and is the closest in mass and size to its orbital neighbour Earth. Venus has by far the densest atmosphere of the terrestrial planets, composed mostly of carbon dioxide with a thick, global sulfuric acid cloud cover. At the surface it has a mean temperature of 737 K (464 °C; 867 °F) and a pressure 92 times that of Earth's at sea level. These extreme conditions compress carbon dioxide into a supercritical state at Venus's surface.",
                AccentColorStart = Color.FromArgb("#A6393B"),
                AccentColorEnd = Color.FromArgb("#D17F21"),
                Images = new List<string>
                {
                    "https://c02.purpledshub.com/uploads/sites/48/2023/12/venus-atmosphere.jpg",
                    "https://cdn.mos.cms.futurecdn.net/RifjtkFLBEFgzkZqWEh69P.jpg",
                    "https://cdn.britannica.com/09/78009-050-49FFFBA9/ultraviolet-light-Venus-spacecraft-Pioneer-Orbiter-bands-Feb-26-1979.jpg",
                    "https://cdn.britannica.com/44/21144-050-64C80234/topography-image-Venus-radar-data-clouds-spacecraft.jpg?w=400&h=225&c=crop"
                }
            },
            new Planet()
            {
                Name = "Earth",
                Subtitle = "The cradle of life",
                HeroImage = "earth.png",
                Description = "Earth is the third planet from the Sun and the only astronomical object known to harbor life. This is enabled by Earth being an ocean world, the only one in the Solar System sustaining liquid surface water. Almost all of Earth's water is contained in its global ocean, covering 70.8% of Earth's crust. The remaining 29.2% of Earth's crust is land, most of which is located in the form of continental landmasses within Earth's land hemisphere. Most of Earth's land is at least somewhat humid and covered by vegetation, while large sheets of ice at Earth's polar deserts retain more water than Earth's groundwater, lakes, rivers, and atmospheric water combined. Earth's crust consists of slowly moving tectonic plates, which interact to produce mountain ranges, volcanoes, and earthquakes. Earth has a liquid outer core that generates a magnetosphere capable of deflecting most of the destructive solar winds and cosmic radiation.",
                AccentColorStart = Color.FromArgb("#0E3D68"),
                AccentColorEnd = Color.FromArgb("#2E97C7"),
                Images = new List<string>
                {
                    "https://media.istockphoto.com/id/172248581/photo/earth-and-moon.jpg?s=612x612&w=0&k=20&c=HVu_JuMcDhEGubM99Vj1yKxl9Nz23iNMShHZXP1eS1E=",
                    "https://t3.ftcdn.net/jpg/03/76/42/72/360_F_376427215_ZZ8oSrVkkZkijSkKi4joP05VbrmeLDCk.jpg",
                    "https://images.newscientist.com/wp-content/uploads/2019/09/09162708/iss048-e-2035_lrg.jpg?width=778"
                }
            },
            new Planet()
            {
                Name = "Mars",
                Subtitle = "The red beauty",
                HeroImage = "mars.png",
                Description = "Mars is the fourth planet from the Sun. The surface of Mars is orange-red because it is covered in iron(III) oxide dust, giving it the nickname \"the Red Planet\". Mars is among the brightest objects in Earth's sky, and its high-contrast albedo features have made it a common subject for telescope viewing. It is classified as a terrestrial planet and is the second smallest of the Solar System's planets with a diameter of 6,779 km (4,212 mi). In terms of orbital motion, a Martian solar day (sol) is equal to 24.6 hours, and a Martian solar year is equal to 1.88 Earth years (687 Earth days). Mars has two natural satellites that are small and irregular in shape: Phobos and Deimos.",
                AccentColorStart = Color.FromArgb("#A23036"),
                AccentColorEnd = Color.FromArgb("#EB3333"),
                Images = new List<string>
                {
                   "https://images.newscientist.com/wp-content/uploads/2025/01/14142430/SEI_235253969.jpg",
                   "https://www.worldatlas.com/r/w1300-q80/upload/bb/c3/32/shutterstock-1041249343.jpg",
                   "https://www.openaccessgovernment.org/wp-content/uploads/2021/04/dreamstime_xxl_121672573-scaled.jpg"
                }
            },
            new Planet()
            {
                Name = "Jupiter",
                Subtitle = "The gas giant",
                HeroImage = "jupiter.png",
                Description = "Jupiter is the fifth planet from the Sun and the largest in the Solar System. It is a gas giant with a mass more than 2.5 times that of all the other planets in the Solar System combined and slightly less than one-thousandth the mass of the Sun. Its diameter is eleven times that of Earth, and a tenth that of the Sun. Jupiter orbits the Sun at a distance of 5.20 AU (778.5 Gm), with an orbital period of 11.86 years. It is the third-brightest natural object in the Earth's night sky, after the Moon and Venus, and has been observed since prehistoric times. Its name derives from that of Jupiter, the chief deity of ancient Roman religion.",
                AccentColorStart = Color.FromArgb("#9D4A40"),
                AccentColorEnd = Color.FromArgb("#CD8026"),
                Images = new List<string>
                {
                   "https://noirlab.edu/public/media/archives/images/screen/noirlab2116e.jpg",
                   "https://upload.wikimedia.org/wikipedia/commons/2/2b/Jupiter_and_its_shrunken_Great_Red_Spot.jpg",
                   "https://platform.vox.com/wp-content/uploads/sites/2/chorus/uploads/chorus_asset/file/10842939/pia21974.jpg?quality=90&strip=all&crop=24.6123521682,0,50.775295663601,100"
                }
            },
            new Planet()
            {
                Name = "Saturn",
                Subtitle = "The ring giant",
                HeroImage = "saturn.png",
                Description = "Saturn is the sixth planet from the Sun and the second largest in the Solar System, after Jupiter. It is a gas giant, with an average radius of about nine times that of Earth. It has an eighth the average density of Earth, but is over 95 times more massive. Even though Saturn is almost as big as Jupiter, Saturn has less than a third its mass. Saturn orbits the Sun at a distance of 9.59 AU (1,434 million km), with an orbital period of 29.45 years.\r\n\r\nSaturn's interior is thought to be composed of a rocky core, surrounded by a deep layer of metallic hydrogen, an intermediate layer of liquid hydrogen and liquid helium, and an outer layer of gas. Saturn has a pale yellow hue, due to ammonia crystals in its upper atmosphere. An electrical current in the metallic hydrogen layer is thought to give rise to Saturn's planetary magnetic field, which is weaker than Earth's, but has a magnetic moment 580 times that of Earth because of Saturn's greater size. Saturn's magnetic field strength is about a twentieth that of Jupiter. The outer atmosphere is generally bland and lacking in contrast, although long-lived features can appear. Wind speeds on Saturn can reach 1,800 kilometres per hour (1,100 miles per hour).",
                AccentColorStart = Color.FromArgb("#996237"),
                AccentColorEnd = Color.FromArgb("#C6502F"),
                Images = new List<string>
                {
                   "https://static.vecteezy.com/system/resources/thumbnails/038/024/589/small_2x/ai-generated-saturn-planet-in-space-celestial-cosmic-solar-system-astronomy-universe-galactic-planetary-photo.jpg",
                   "https://www.treehugger.com/thmb/dmsgnu_xOjPYWLywnUZKeZ7msjc=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/__opt__aboutcom__coeus__resources__content_migration__mnn__images__2013__02__saturnvoyager-4d4819cec3c845c8a90eaa348319a08f.jpg",
                   "https://i.ytimg.com/vi/gU0vt9spTJc/hq720.jpg?sqp=-oaymwEhCK4FEIIDSFryq4qpAxMIARUAAAAAGAElAADIQj0AgKJD&rs=AOn4CLCBd-c3oBZ2d07cx4ElpMHrcWU-6A",
                   "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSmcBoB2jwEXRhVOLc8phCSIDWsBGqjDyM3VQ&s"
                }
            },
            new Planet()
            {
                Name = "Uranus",
                Subtitle = "The Herschel giant",
                HeroImage = "uranus.png",
                Description = "Uranus is the seventh planet from the Sun. It is a gaseous cyan-coloured ice giant. Most of the planet is made of water, ammonia, and methane in a supercritical phase of matter, which astronomy calls \"ice\" or volatiles. The planet's atmosphere has a complex layered cloud structure and has the lowest minimum temperature (49 K (−224 °C; −371 °F)) of all the Solar System's planets. It has a marked axial tilt of 82.23° with a retrograde rotation period of 17 hours and 14 minutes. This means that in an 84-Earth-year orbital period around the Sun, its poles get around 42 years of continuous sunlight, followed by 42 years of continuous darkness.\r\n\r\nUranus has the third-largest diameter and fourth-largest mass among the Solar System's planets. Based on current models, inside its volatile mantle layer is a rocky core, and surrounding it is a thick hydrogen and helium atmosphere. Trace amounts of hydrocarbons (thought to be produced via hydrolysis) and carbon monoxide along with carbon dioxide (thought to have been originated from comets) have been detected in the upper atmosphere. There are many unexplained climate phenomena in Uranus's atmosphere, such as its peak wind speed of 900 km/h (560 mph), variations in its polar cap, and its erratic cloud formation. The planet also has very low internal heat compared to other giant planets, the cause of which remains unclear.",
                AccentColorStart = Color.FromArgb("#9D4A40"),
                AccentColorEnd = Color.FromArgb("#996237"),
                Images = new List<string>
                {
                   "https://assets.science.nasa.gov/dynamicimage/assets/science/psd/solar/2023/09/p/i/a/0/PIA01492-1.jpg?w=2188&h=2185&fit=clip&crop=faces%2Cfocalpoint",
                   "https://media.istockphoto.com/id/1199283538/photo/planet-uranus.jpg?s=612x612&w=0&k=20&c=ywhCXwqp1G17DDGvSN4FoFHcBr24W__TjulMRju4ZWk=",
                   "https://images.newscientist.com/wp-content/uploads/2024/11/11145255/SEI_228852345.jpg?crop=1:1,smart&width=1200&height=1200&upscale=true"
                }
            },
            new Planet()
            {
                Name = "Neptune",
                Subtitle = "The god of the sea",
                HeroImage = "neptune.png",
                Description = "Neptune is the eighth and farthest known planet from the Sun. It is the fourth-largest planet in the Solar System by diameter, the third-most-massive planet, and the densest giant planet. It is 17 times the mass of Earth. Compared to its fellow ice giant Uranus, Neptune is slightly more massive, but denser and smaller. Being composed primarily of gases and liquids, it has no well-defined solid surface, and orbits the Sun once every 164.8 years at an orbital distance of 30.1 astronomical units (4.5 billion kilometres; 2.8 billion miles). It is named after the Roman god of the sea and has the astronomical symbol ♆, representing Neptune's trident.\r\n\r\nNeptune is not visible to the unaided eye and is the only planet in the Solar System that was not initially observed by direct empirical observation. Rather, unexpected changes in the orbit of Uranus led Alexis Bouvard to hypothesise that its orbit was subject to gravitational perturbation by an unknown planet. After Bouvard's death, the position of Neptune was mathematically predicted from his observations, independently, by John Couch Adams and Urbain Le Verrier. Neptune was subsequently directly observed with a telescope on 23 September 1846 by Johann Gottfried Galle within a degree of the position predicted by Le Verrier. Its largest moon, Triton, was discovered shortly thereafter, though none of the planet's remaining moons were located telescopically until the 20th century.",
                AccentColorStart = Color.FromArgb("#0C293D"),
                AccentColorEnd = Color.FromArgb("#26ABE0"),
                Images = new List<string>
                {
                    "https://cdn.mos.cms.futurecdn.net/PezBzd9Fehsq9XWgWMauVV-1200-80.jpg",
                    "https://upload.wikimedia.org/wikipedia/commons/thumb/6/63/Neptune_-_Voyager_2_%2829347980845%29_flatten_crop.jpg/200px-Neptune_-_Voyager_2_%2829347980845%29_flatten_crop.jpg",
                    "https://cdn.mos.cms.futurecdn.net/jnDUxz76QEjPLR4rmUrbz3-320-80.jpg"
                }
            },
            new Planet()
            {
                Name = "Pluto",
                Subtitle = "The 'ninth' planet",
                HeroImage = "pluto.png",
                Description = "Pluto has a moderately eccentric and inclined orbit, ranging from 30 to 49 astronomical units (4.5 to 7.3 billion kilometres; 2.8 to 4.6 billion miles) from the Sun. Light from the Sun takes 5.5 hours to reach Pluto at its orbital distance of 39.5 AU (5.91 billion km; 3.67 billion mi). Pluto's eccentric orbit periodically brings it closer to the Sun than Neptune, but a stable orbital resonance prevents them from colliding.",
                AccentColorStart = Color.FromArgb("#b8915c"),
                AccentColorEnd = Color.FromArgb("#8f6a39"),
                Images = new List<string>
                {
                    "https://upload.wikimedia.org/wikipedia/commons/thumb/e/ef/Pluto_in_True_Color_-_High-Res.jpg/435px-Pluto_in_True_Color_-_High-Res.jpg",
                    "https://science.nasa.gov/wp-content/uploads/2016/05/screenshot-2023-11-02-at-4.28.52-pm.png",
                    "https://images.newscientist.com/wp-content/uploads/2016/03/p_color2_enhanced_release_black_smaller.jpg?crop=1:1,smart&width=1200&height=1200&upscale=true",
                }
            },
            new Planet()
            {
                Name = "Ceres",
                Subtitle = "The quarter moon",
                HeroImage = "ceres.png",
                Description = "Ceres' diameter is about a quarter that of the Moon. Its small size means that even at its brightest it is too dim to be seen by the naked eye, except under extremely dark skies. Its apparent magnitude ranges from 6.7 to 9.3, peaking at opposition (when it is closest to Earth) once every 15- to 16-month synodic period. As a result, its surface features are barely visible even with the most powerful telescopes, and little was known about it until the robotic NASA spacecraft Dawn approached Ceres for its orbital mission in 2015.",
                AccentColorStart = Color.FromArgb("#b3a38f"),
                AccentColorEnd = Color.FromArgb("#827668"),
                Images = new List<string>
                {
                    "https://upload.wikimedia.org/wikipedia/commons/thumb/7/76/Ceres_-_RC3_-_Haulani_Crater_%2822381131691%29_%28cropped%29.jpg/800px-Ceres_-_RC3_-_Haulani_Crater_%2822381131691%29_%28cropped%29.jpg",
                    "https://www.solarsystemscope.com/spacepedia/images/handbook/renders/ceres.png",
                    "https://cff2.earth.com/uploads/2024/12/13191006/ceres_dwarf-planet_water-rich_organic-matter_possible-life_1.jpg"
                }
            },
            new Planet()
            {
                Name = "Haumea",
                Subtitle = "The Hawaiian goddess",
                HeroImage = "haumea.png",
                Description = "Haumea's mass is about one-third that of Pluto and 1/1400 that of Earth. Although its shape has not been directly observed, calculations from its light curve are consistent with it being a Jacobi ellipsoid (the shape it would be if it were a dwarf planet), with its major axis twice as long as its minor. In October 2017, astronomers announced the discovery of a ring system around Haumea, representing the first ring system discovered for a trans-Neptunian object and a dwarf planet.\r\n\r\nHaumea's gravity was until recently thought to be sufficient for it to have relaxed into hydrostatic equilibrium, though that is now unclear. Haumea's elongated shape together with its rapid rotation, rings, and high albedo (from a surface of crystalline water ice), are thought to be the consequences of a giant collision, which left Haumea the largest member of a collisional family (the Haumea family) that includes several large trans-Neptunian objects and Haumea's two known moons, Hiʻiaka and Namaka.",
                AccentColorStart = Color.FromArgb("#5e574f"),
                AccentColorEnd = Color.FromArgb("#45403a"),
                Images = new List<string>
                {
                    "https://science.nasa.gov/wp-content/uploads/2023/07/haumea-480x320-1-jpg.webp?w=320",
                    "https://static.wikia.nocookie.net/sailormoonfanon/images/5/5d/Haumea.jpg/revision/latest?cb=20181029070238",
                    "https://i.guim.co.uk/img/media/8ba455b0fcc4943d263e08ba334c7dfaba690991/163_652_3543_2126/master/3543.jpg?width=1200&height=1200&quality=85&auto=format&fit=crop&s=afd8e15c143dbb88db21179301109a80"
                }
            },
            new Planet()
            {
                Name = "MakeMake",
                Subtitle = "The icy dwarf",
                HeroImage = "makemake.png",
                Description = "Makemake (minor-planet designation: 136472 Makemake) is a dwarf planet and the largest of what is known as the classical population of Kuiper belt objects,[b] with a diameter approximately that of Saturn's moon Iapetus, or 60% that of Pluto.[24][25] It has one known satellite.[26] Its extremely low average temperature, about 40 K (−230 °C), means its surface is covered with methane, ethane, and possibly nitrogen ices.[21] Makemake shows signs of geothermal activity and thus may be capable of supporting active geology and harboring an active subsurface ocean.",
                AccentColorStart = Color.FromArgb("#8f533c"),
                AccentColorEnd = Color.FromArgb("#704331"),
                Images = new List<string>
                {
                    "https://cdn.mos.cms.futurecdn.net/8QBGiy9BhmttKdGeAAZpn8.jpg",
                    "https://theplanets.org/123/2021/11/Dwarf-Planet-Makemake.png",
                    "https://www.astronomy.com/uploads/2021/09/Makemake-1.jpg"
                }
            },
            new Planet()
            {
                Name = "Eris",
                Subtitle = "The Greek goddess Eris",
                HeroImage = "eris.png",
                Description = "Eris (minor-planet designation: 136199 Eris) is the most massive and second-largest known dwarf planet in the Solar System.[22] It is a trans-Neptunian object (TNO) in the scattered disk and has a high-eccentricity orbit. Eris was discovered in January 2005 by a Palomar Observatory–based team led by Mike Brown and verified later that year. It was named in September 2006 after the Greco–Roman goddess of strife and discord. Eris is the ninth-most massive known object orbiting the Sun and the sixteenth-most massive overall in the Solar System (counting moons). It is also the largest known object in the solar system that has not been visited by a spacecraft. Eris has been measured at 2,326 ± 12 kilometres (1,445 ± 7 mi) in diameter;[12] its mass is 0.28% that of the Earth and 27% greater than that of Pluto,[23][24] although Pluto is slightly larger by volume.[25] Both Eris and Pluto have a surface area that is comparable to that of Russia or South America.\r\n\r\nEris has one large known moon, Dysnomia. In February 2016, Eris's distance from the Sun was 96.3 AU (14.41 billion km; 8.95 billion mi),[20] more than three times that of Neptune or Pluto. With the exception of long-period comets, Eris and Dysnomia were the most distant known natural objects in the Solar System until the discovery of 2018 AG37 and 2018 VG18 in 2018.[20]",
                AccentColorStart = Color.FromArgb("#d9b19e"),
                AccentColorEnd = Color.FromArgb("#947c70"),
                Images = new List<string>
                {
                    "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSG6gj2_jvLR_vafhxvRxJMZvvR3EEo1a6Ufg&s",
                    "https://cff2.earth.com/uploads/2024/02/20135637/Eris_icy-dwarf-planet_kuiper-belt_1m.jpg",
                    "https://assets.science.nasa.gov/dynamicimage/assets/science/psd/solar/internal_resources/3256/Artists_c_oncept_of_Eris_and_Dysnomia_far_from_the_Sun.jpeg?w=800&h=600&fit=clip&crop=faces%2Cfocalpoint"
                }
            },
        };
        public static List<Planet> GetFeaturedPlanets()
        {
            var rng = new Random();
            var randomizePlanets = planets.OrderBy(p => rng.Next());
            return randomizePlanets.Take(2).ToList();
        }
        public static List<Planet> GetAllPlanets()
        {
            return planets;
        }

    }
}
