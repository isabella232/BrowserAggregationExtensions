﻿using Sitecore.Analytics.Aggregation.Data.Model;
using Sitecore.ExperienceAnalytics.Aggregation.Data.Schema;
using Sitecore.ExperienceAnalytics.Aggregation.Dimensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.AggregationExtensions.ExperienceAnalytics.Aggregation.Dimensions
{
    public class ByBrowserVersion : VisitDimensionBase
    {
        public ByBrowserVersion(Guid dimensionId)
            : base(dimensionId)
        {
        }

        protected override bool HasDimensionKey(IVisitAggregationContext context)
        {
            // need to check the interaction type
            return true;
            // return !string.IsNullOrEmpty(context.Visit.Browser.BrowserMajorName);
        }

        protected override string GetKey(IVisitAggregationContext context)
        {
            string browserMajor = "[UNKNOWN]", browserMinor = "[UNKNOWN]", browserVersion = "[UNKNOWN]";

            if (context.Visit.Browser != null && !string.IsNullOrEmpty(context.Visit.Browser.BrowserMajorName))
            {
                browserMajor = context.Visit.Browser.BrowserMajorName;
            }
            if (context.Visit.Browser != null && !string.IsNullOrEmpty(context.Visit.Browser.BrowserMinorName))
            {
                browserMinor = context.Visit.Browser.BrowserMinorName;
            }
            if (context.Visit.Browser != null && !string.IsNullOrEmpty(context.Visit.Browser.BrowserVersion))
            {
                browserVersion = context.Visit.Browser.BrowserVersion;
            }

            return StringExtensions.ToCanonical(string.Concat(browserMajor, "-", browserMinor, "-", browserVersion));

        }

        protected override SegmentMetricsValue GetValue(IVisitAggregationContext context)
        {
            return base.GetValue(context);
        }
    }
}