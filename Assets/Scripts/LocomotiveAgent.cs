using UnityEngine;

namespace Assets.Scripts
{
    public class LocomotiveAgent : Agent
    {

        protected float speed, maxSpeed, maxDistance;
        protected Vector3 direction;

        public virtual void moveRandom()
        {
            rb.AddForce(direction * speed);
        }

        public void setSpeed(float speed)
        {
            this.speed = speed;
        }

        public float getSpeed()
        {
            return speed;
        }

        public void setDirection(Vector3 movement)
        {
            this.direction = movement;
        }

        public Vector3 getDirection()
        {
            return direction;
        }

        public void setMaxSpeed(float maxSpeed)
        {
            this.maxSpeed = maxSpeed;
        }

        public float getMaxSpeed()
        {
            return maxSpeed;
        }

        public void setMaxDistance(float maxDistance)
        {
            this.maxDistance = maxDistance;
        }

        public float getMaxDistance()
        {
            return maxDistance;
        }

    }
}
