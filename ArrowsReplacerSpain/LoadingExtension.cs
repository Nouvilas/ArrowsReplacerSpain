using System.Collections;
using ICities;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.IO;
using System.Xml.Serialization;

namespace ArrowsReplacerSpain
{

    public class LoadingExtension : LoadingExtensionBase
    {

        public override void OnLevelLoaded(LoadMode mode)
        {
            base.OnLevelLoaded(mode);
            if (mode != LoadMode.LoadGame && mode != LoadMode.NewGame && mode != LoadMode.NewGameFromScenario)
            {
                return;
            }
            var spF = PrefabCollection<PropInfo>.FindLoaded("2008960441.Spanish Arrow Forward_Data");
            var spFL = PrefabCollection<PropInfo>.FindLoaded("2008960441.Spanish Arrow Forward Left_Data");
            var spFLR = PrefabCollection<PropInfo>.FindLoaded("2008960441.Spanish Arrow Forward Left Right_Data");
            var spFR = PrefabCollection<PropInfo>.FindLoaded("2008960441.Spanish Arrow Forward Right_Data");
            var spL = PrefabCollection<PropInfo>.FindLoaded("2008960441.Spanish Arrow Left_Data");
            var spLR = PrefabCollection<PropInfo>.FindLoaded("2008960441.Spanish Arrow Left Right_Data");
            var spR = PrefabCollection<PropInfo>.FindLoaded("2008960441.Spanish Arrow Right_Data");

            if (spF == null || spFL == null || spFLR == null || spFR == null || spL == null || spLR == null || spR == null)
            {
                return;
            }

            var roads = Resources.FindObjectsOfTypeAll<NetInfo>();
            foreach (var road in roads)
            {
                if (road.m_lanes == null)
                {
                    return;
                }
                foreach (var lane in road.m_lanes)
                {
                    if (lane?.m_laneProps?.m_props == null)
                    {
                        continue;
                    }
                    foreach (var laneProp in lane.m_laneProps.m_props)
                    {
                        var prop = laneProp.m_finalProp;
                        if (prop == null)
                        {
                            continue;
                        }

                        var name = prop.name;
                        if (name == "Road Arrow F")
                        {
                            laneProp.m_finalProp = spF;
                            laneProp.m_prop = spF;
                        }
                        else if (name == "Road Arrow LF")
                        {
                            laneProp.m_finalProp = spFL;
                            laneProp.m_prop = spFL;
                        }
                        else if (name == "Road Arrow LFR")
                        {
                            laneProp.m_finalProp = spFLR;
                            laneProp.m_prop = spFLR;
                        }
                        else if (name == "Road Arrow FR")
                        {
                            laneProp.m_finalProp = spFR;
                            laneProp.m_prop = spFR;
                        }
                        else if (name == "Road Arrow L")
                        {
                            laneProp.m_finalProp = spL;
                            laneProp.m_prop = spL;
                        }
                        else if (name == "Road Arrow LR")
                        {
                            laneProp.m_finalProp = spLR;
                            laneProp.m_prop = spLR;
                        }
                        else if (name == "Road Arrow R")
                        {
                            laneProp.m_finalProp = spR;
                            laneProp.m_prop = spR;
                        }
                    }
                }
            }
        }
    }
}