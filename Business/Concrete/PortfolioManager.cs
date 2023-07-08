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
    public class PortfolioManager : IPortfolioService
    {
        IPortfolioDal _portfolioDal;

        public PortfolioManager(IPortfolioDal portfolioDal)
        {
            _portfolioDal = portfolioDal;
        }

        public IResult Add(Portfolio portfolio)
        {
            _portfolioDal.Add(portfolio);
            return new SuccessResult(Messages.PortfolioAdded);
        }

        public IResult Delete(int id)
        {
            var deletedPortfolio = _portfolioDal.Get(x => x.PortfolioID == id);
            return new SuccessResult($"Deleted portfolio: {id} number's {Messages.PortfolioDeleted}");
        }

        public IDataResult<List<Portfolio>> GetAll()
        {
            var listedPortfolio = _portfolioDal.GetAll();
            return new SuccessDataResult<List<Portfolio>>(listedPortfolio, Messages.PortfolioGetAll);
        }

        public IResult GetById(int portfolioId)
        {
            var listPortfolioGetById = _portfolioDal.Get(x => x.PortfolioID == portfolioId);
            return new SuccessDataResult<Portfolio>(listPortfolioGetById, Messages.PortfolioGetById);
        }

        public IResult Update(Portfolio portfolio)
        {
            var updatePortfolio = _portfolioDal.Get(x => x.PortfolioID == portfolio.PortfolioID);
            Portfolio updatedPortfolio = new Portfolio()
            {
                PortfolioID = portfolio.PortfolioID,
                ImageUrl = portfolio.ImageUrl,
                Name = portfolio.Name
            };
            _portfolioDal.Update(updatedPortfolio);
            return new SuccessResult(Messages.PortfolioUpdated);
        }
    }
}
