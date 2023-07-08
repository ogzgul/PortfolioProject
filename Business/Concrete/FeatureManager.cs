using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FeatureManager : IFeatureService
    {
        IFeatureDal _featureDal;

        public FeatureManager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public IResult Add(Feature feature)
        {
            _featureDal.Add(feature);
            return new SuccessResult(Messages.FeatureAdded);
        }

        public IResult Delete(int id)
        {
            var deletedFeature = _featureDal.Get(x => x.FeatureID == id);
            return new SuccessResult($"Deleted feature: {id} number's {Messages.FeatureDeleted}");
        }

        public IDataResult<List<Feature>> GetAll()
        {
            var listedFeature = _featureDal.GetAll();
            return new SuccessDataResult<List<Feature>>(listedFeature, Messages.FeatureGetAll);
        }

        public IResult GetById(int featureId)
        {
            var listFeatureGetById = _featureDal.Get(x => x.FeatureID == featureId);
            return new SuccessDataResult<Feature>(listFeatureGetById, Messages.FeatureGetById);
        }

        public IResult Update(Feature feature)
        {
            var updateFeature = _featureDal.Get(x => x.FeatureID == feature.FeatureID);
            Feature updatedFeature = new Feature()
            {
                FeatureID = feature.FeatureID,
                Header = feature.Header,
                Name = feature.Name,
                Title = feature.Title
            };
            _featureDal.Update(updatedFeature);
            return new SuccessResult(Messages.FeatureUpdated);
        }
    }
}
