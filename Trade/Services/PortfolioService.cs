using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Trade.Data.Models;
using Trade.Data.Repositories;
using Trade.Models;

namespace Trade.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly ICurrentUserScope _currentUserScope;
        private readonly IMapper _mapper;
        private readonly IPositionService _positionService;
        private readonly IPortfolioRepository _portfolioRepository;

        public PortfolioService(
            ICurrentUserScope currentUserScope, 
            IMapper mapper, 
            IPositionService positionService, 
            IPortfolioRepository portfolioRepository)
        {
            _currentUserScope = currentUserScope;
            _mapper = mapper;
            _positionService = positionService;
            _portfolioRepository = portfolioRepository;
        }

        public async Task<IEnumerable<PortfolioModel>> GetAll()
        {
            var portfolios = await _portfolioRepository.GetOwnedPortfolios(_currentUserScope.UserId);
            return _mapper.Map<IEnumerable<PortfolioModel>>(portfolios);
        }

        public async Task<PortfolioModel> GetById(int id)
        {
            var portfolio = await _portfolioRepository.Get(id);
            if (portfolio.OwnerId != _currentUserScope.UserId)
            {
                throw new Exception("Not found");
            }

            var model = _mapper.Map<PortfolioModel>(portfolio);
            model.Positions = await _positionService.GetPositions(id);
            return model;
        }

        public async Task<PortfolioModel> Create(PortfolioModel model)
        {
            var entity = _mapper.Map<Portfolio>(model);
            entity.OwnerId = _currentUserScope.UserId;
            
            await _portfolioRepository.Insert(entity);

            var result = _mapper.Map<PortfolioModel>(entity);
            result.Positions = await _positionService.CreatePositions(entity.Id, model.Positions);
            return result;
        }

        public async Task<PortfolioModel> Update(PortfolioModel model)
        {
            var entity = _mapper.Map<Portfolio>(model);
            await _portfolioRepository.Update(entity);
            return _mapper.Map<PortfolioModel>(entity);
        }

        public async Task Delete(int id)
        {
            await _portfolioRepository.DeleteMyPortfolio(id, _currentUserScope.UserId);
        }
    }
}