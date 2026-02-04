using NUnit.Framework;
using UnityEngine;
using UnityEngine.XR;


namespace Solution
{
    public class Character : Identity
    {
        [Header("Character")]
        public int energy;
        public int AttackPoint;

        public bool isAlive = true;

        // Start is called before the first frame update
        protected void GetRemainEnergy()
        {

        }

        public virtual void Move(Vector2 direction)
        {
            int toX = (int)(positionX+ direction.x);
            int toY = (int)(positionY+ direction.y);

            if(HasPlacement(toX, toY)){
                Debug.Log("can't move");
                Identity identity = mapGenerator.GetMapData(toX,toY);
                identity.Hit(this);
            }
            else
            {
                mapGenerator.UpdatePositionIdenity(this,toX,toY);
                TakeDamage(1);
            }
           
        }
        // hasPlacement �׹��� true ����ա���ҧ������麹 map �����˹� x,y
        public bool HasPlacement(int x, int y)
        {
            var cell = mapGenerator.GetMapData(x,y);
            return cell != null;
        }
        

        public virtual void TakeDamage(int Damage)
        {
            energy -= Damage;
            CheckDead();
        }
        


        public void Heal(int healPoint)
        {
            energy += healPoint;
            Debug.Log("Current Energy : " + energy);
        }


        protected virtual void CheckDead()
        {
            if (energy <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}