﻿using System;
using System.Collections.Generic;

namespace NameLib
{
    public static partial class NameParser
    {
        public static List<NameObject> RunNames(List<string> names)
        {

            var returnList = new List<NameObject>();
            var workList = new List<NameObject>();
            var allNames = new List<string>();
            var uniqueNames = new List<string>();
            foreach (var name in names)
            {
                var listNames = name.Split(' ');
                foreach (var eachName in listNames)
                {
                    allNames.Add(eachName);
                    if (!uniqueNames.Contains(eachName))
                    {
                        uniqueNames.Add(eachName);
                    }
                }
            }

            foreach (var name in uniqueNames)
            {
                var count = 0;
                foreach (var innerName in allNames)
                {
                    if (innerName.Equals(name))
                        count++;
                }
                workList.Add(new NameObject { Name = name, NumberOfAppearances = count });
            }

            workList.Sort(
                delegate( NameObject o1, NameObject o2) {
                    int compareAppearances = o2.NumberOfAppearances.CompareTo(o1.NumberOfAppearances);
                    if (compareAppearances == 0)
                    {
                        return o1.Name.CompareTo(o2.Name);
                    }
                    return compareAppearances;
                });

            foreach (var element in workList)
            {
                returnList.Add(element);
                if (returnList.Count == 3)
                    break;
            }

            return returnList;
        }
    }
}
