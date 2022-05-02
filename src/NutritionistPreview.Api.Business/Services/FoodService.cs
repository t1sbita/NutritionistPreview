using Microsoft.Extensions.Logging;
using NutritionistPreview.Api.Business.Services.Base;
using NutritionistPreview.Api.Business.Services.Interfaces;
using NutritionistPreview.Api.Core.Domain.Dto;
using NutritionistPreview.Api.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionistPreview.Api.Business.Services
{
    public class FoodService : BaseService<Food>, IFoodService
    {
        public FoodService(ILogger<Food> logger) : base(logger)
        {

        }

        public Task<List<Diet>> GetOptions(double caloricAmount)
        {
            List<Diet> options = new();
            var groupA = CreateListOfFruits().Where(x => x.Group == "A").ToArray();
            var groupB = CreateListOfFruits().Where(x => x.Group == "B").ToArray();
            var groupC = CreateListOfFruits().Where(x => x.Group == "C").ToArray();

            for (int i = 0; i < groupA.Length; i++)
            {
                for (int j = 0; j < groupB.Length; j++)
                {
                    for (int k = 0; k < groupC.Length; k++)
                    {
                        List<Food> foods = new();
                        int amount = 0;

                        foods.Add(groupA[i]);
                        foods.Add(groupB[j]);
                        foods.Add(groupC[k]);
                        foods.ForEach(x => amount += x.CaloricAmount);
                        options.Add(new Diet() { Foods = foods, TotalCaloricAmount = amount });
                    }

                }
            }
            return Task.FromResult(options.Where(x => x.TotalCaloricAmount < caloricAmount).ToList());
        }

        private static List<Food> CreateListOfFruits()
        {
            return new List<Food>()
            {
                new Food(){ Name = "Banana", Group = "A", CaloricAmount = 250},
                new Food(){ Name = "Arroz", Group = "B", CaloricAmount = 400},
                new Food(){ Name = "Pessego", Group = "C", CaloricAmount = 200},
                new Food(){ Name = "Feijão", Group = "A", CaloricAmount = 300},
                new Food(){ Name = "Carne", Group = "B", CaloricAmount = 600},
                new Food(){ Name = "Frango", Group = "C", CaloricAmount = 350},
                new Food(){ Name = "Berinjela", Group = "A", CaloricAmount = 90},
                new Food(){ Name = "Chocolate", Group = "B", CaloricAmount = 760},
                new Food(){ Name = "Leite", Group = "C", CaloricAmount = 320},
                new Food(){ Name = "Goiabada", Group = "A", CaloricAmount = 670},
                new Food(){ Name = "Pernil", Group = "B", CaloricAmount = 950},
                new Food(){ Name = "Hamburguer", Group = "C", CaloricAmount = 1230},
                new Food(){ Name = "Couve", Group = "A", CaloricAmount = 30},
                new Food(){ Name = "Biscoito", Group = "B", CaloricAmount = 270},
                new Food(){ Name = "Guisado", Group = "C", CaloricAmount = 650},
                new Food(){ Name = "Pão", Group = "A", CaloricAmount = 390},
                new Food(){ Name = "Ovo", Group = "B", CaloricAmount = 210},
                new Food(){ Name = "Queijo", Group = "C", CaloricAmount = 650},
                new Food(){ Name = "Presunto", Group = "A", CaloricAmount = 850},
                new Food(){ Name = "Batata", Group = "B", CaloricAmount = 780},
                new Food(){ Name = "Torrada", Group = "C", CaloricAmount = 490},
                new Food(){ Name = "Sopa", Group = "A", CaloricAmount = 700},
                new Food(){ Name = "Macarrão", Group = "B", CaloricAmount = 470},
                new Food(){ Name = "Pizza", Group = "C", CaloricAmount = 1000},
                new Food(){ Name = "Pudim", Group = "A", CaloricAmount = 850},
                new Food(){ Name = "Salada", Group = "B", CaloricAmount = 150},
                new Food(){ Name = "Aipim", Group = "C", CaloricAmount = 250},

            };
        }
    }
}
