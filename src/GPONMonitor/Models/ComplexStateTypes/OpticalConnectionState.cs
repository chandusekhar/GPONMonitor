﻿using System.Collections.Generic;

namespace GPONMonitor.Models.Onu
{
    public class OpticalConnectionState
    {
        public int? Value
        {
            get
            {
                return Value;
            }
            set
            {
                ResponseDescription responseDescription;

                if (OpticalConnectionStateResponseDictionary.ContainsKey(value))
                {
                    OpticalConnectionStateResponseDictionary.TryGetValue(value, out responseDescription);
                }
                else
                {
                    OpticalConnectionStateResponseDictionary.TryGetValue(null, out responseDescription);
                }

                DescriptionEng = responseDescription.DescriptionEng;
                DescriptionPol = responseDescription.DescriptionPol;
                Severity = responseDescription.Severity;

                Value = value;
            }
        }

        public string DescriptionEng { get; private set; }
        public string DescriptionPol { get; private set; }
        public SeverityLevel Severity { get; private set; }


        // ONU Link Status
        // 0 - invalid
        // 1 - inactive
        // 2 - active
        // 3 - running (OBSOLETE: removed in 5.08)

        readonly Dictionary<int?, ResponseDescription> OpticalConnectionStateResponseDictionary = new Dictionary<int?, ResponseDescription>()
        {
            { null, new ResponseDescription("unknown", "brak odczytu", SeverityLevel.Unknown) },
            { 0, new ResponseDescription("invalid", "niepoprawne", SeverityLevel.Danger) },
            { 1, new ResponseDescription("inactive", "nieaktywne", SeverityLevel.Danger) },
            { 2, new ResponseDescription("active", "aktywne", SeverityLevel.Success) },
            { 3, new ResponseDescription("running", "działające", SeverityLevel.Success) }
        };
    }
}