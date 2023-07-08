using Business.Abstract;
using Business.Concrete;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PortfolioProject.ViewComponents.Feature
{
    public class FeatureList:ViewComponent
    {
        FeatureManager _featureManager = new FeatureManager(new EfFeatureDal());
        public IViewComponentResult Invoke()
        {
            var values = _featureManager.GetAll().Data;
            return View(values);
        }
    }
}
