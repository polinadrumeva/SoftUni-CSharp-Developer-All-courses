using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController
	{
		private readonly IList<Character> party;
		private readonly Stack<Item> pool;

		public WarController()
		{
			this.party = new List<Character>();
			this.pool = new Stack<Item>();
		}

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string name = args[1]; 
			Character character;
			if (characterType == "Warrior")
			{
				character = new Warrior(name);
			}
			else if (characterType == "Priest")
			{
				character = new Priest(name);
			}
            else
            {
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
			}

			this.party.Add(character);
			return string.Format(SuccessMessages.JoinParty, name);
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];

			Item item;
			if (itemName == "FirePotion")
			{
				item = new FirePotion();
			}
			else if (itemName == "HealthPotion")
			{
				item = new HealthPotion();
			}
			else
			{
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName));
			}

			this.pool.Push(item);
			return string.Format(SuccessMessages.AddItemToPool, itemName);
		}

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];
			Character character = this.party.FirstOrDefault(c => c.Name == characterName);
			if (character == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}

            if (this.pool.Count == 0)
            {
				throw new InvalidOperationException(string.Format(ExceptionMessages.ItemPoolEmpty));
			}

			Item item = this.pool.Pop();
			character.Bag.AddItem(item);
			return string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);
		}
	

		public string UseItem(string[] args)
		{
			
			string characterName = args[0];
			string itemName = args[1];
			Character character = this.party.FirstOrDefault(c => c.Name == characterName);
			if (character == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}

			if (character.Bag.Items.Count == 0)
			{
				throw new InvalidOperationException(string.Format(ExceptionMessages.EmptyBag));
			}
			
			Item item = this.pool.FirstOrDefault(i => i.GetType().Name == itemName);
			if (!character.Bag.Items.Contains(item))
			{
				throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotFoundInBag, itemName));
			}

			character.UseItem(item);
			return string.Format(SuccessMessages.UsedItem, characterName, item.GetType().Name);
		}

		public string GetStats()
		{
			StringBuilder stringBuilder = new StringBuilder();
            foreach (var characher in this.party.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health))
            {
				string alive;
				if (characher.IsAlive)
                {
					alive = "Alive";
                }
                else
                {
					alive = "Dead";
				}
				stringBuilder.AppendLine($"{characher.Name} - HP: {characher.Health}/{characher.BaseHealth}, AP: {characher.Armor}/{characher.BaseArmor}, Status: {alive}");
            }

			return stringBuilder.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string receiverName = args[1];
			Warrior attacker = (Warrior)this.party.FirstOrDefault(c => c.Name == attackerName);
			Character receiver = this.party.FirstOrDefault(c => c.Name == receiverName);
			if (attacker == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
			}
			else if (receiver == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
			}


			attacker.Attack(receiver);
            if (receiver.Health <= 0)
            {
				return String.Format(SuccessMessages.AttackCharacter, attackerName, receiver.Name, attacker.AbilityPoints, receiverName, receiver.Health, receiver.BaseHealth, receiver.Armor, receiver.BaseArmor, SuccessMessages.AttackKillsCharacter, receiverName);
			}
            else
            {
				return String.Format(SuccessMessages.AttackCharacter, attackerName, receiver.Name, attacker.AbilityPoints, receiverName, receiver.Health, receiver.BaseHealth, receiver.Armor, receiver.BaseArmor);
            }
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string healingReceiverName = args[1];

			Priest healer = (Priest)this.party.FirstOrDefault(c => c.Name == healerName);
			Character receiver = this.party.FirstOrDefault(c => c.Name == healingReceiverName);
			if (healer == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty));
			}
			else if (receiver == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty));
			}

			if (!this.party.Contains(healer) || !this.party.Contains(receiver))
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty));
			}

			healer.Heal(receiver);
			return String.Format(SuccessMessages.HealCharacter, healer.Name, receiver.Name, healer.AbilityPoints, receiver.Name, receiver.Health);
			
			
		}
	}
}

