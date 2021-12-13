using System;
using System.Collections.Generic;
using System.Linq;
using StarWars.Domain.Entities;
using StarWars.Domain.Interfaces;

namespace StarWars.Application
{
    public class ItemApplication : IItemApplication
    {
        #region Properties

        private readonly INotificator _notificator;
        private readonly IItemRepository _itemRepository;

        #endregion

        #region Constructors

        public ItemApplication(INotificator notificator, IItemRepository itemRepository)
        {
            _notificator = notificator;
            _itemRepository = itemRepository;
        }
        #endregion

        #region Public Methods
        public bool ItensExistem(IEnumerable<Item> itens)
        {
            var item = _itemRepository.ItensExistem(itens);

            if (item != null)
            {
                var msg = @$"Não há item com Nome = {item.Nome} e Ponto = {item.Ponto}.Os itens existente são: Arma - 4 pontos; Munição - 3 pontos; Água - 2 pontos; Comida - 1 ponto";
                _notificator.AddError(msg);
                return false;
            }

            return true;
        }

        #endregion
    }
}