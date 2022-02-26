using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WarofArmies.Classes
{
    public class Soldier
    {
        public static int power { get; set; } = 1;
        public double health { get; set; } = 100;
        public Armor armor { get; set; }
        public Weapon weapon { get; set; } 
        public bool isAlive { get; set; }
        public bool isHaveEnemy { get; set; }
        public Soldier enemy;
        public Army myArmy;
        public string soldierName;
        public static int soldierId = 0;

        public Soldier(Army myArmy,Weapon weapon,Armor armor)
        {
            this.weapon = weapon;
            this.armor = armor;
            this.myArmy = myArmy;
            soldierName = "Soldier" + soldierId;
            soldierId++;
        }

        public void findEnemy()
        {
            enemy = myArmy.findEnemy(this);
            isHaveEnemy = true;
        }

        public void attackToEnemy()
        {
            enemy = weapon.attack(enemy);
            Console.WriteLine(this.soldierName + " Health Point  : " + this.health.ToString());
            Console.WriteLine(this.soldierName + "My Enemy" + enemy.soldierName);
            if (enemy.health <= 0)
            {
                enemy.isAlive = false;
                myArmy.deleteEnemy(enemy);
                isHaveEnemy = false;
                findEnemy();                
            }
        }
    }
}
