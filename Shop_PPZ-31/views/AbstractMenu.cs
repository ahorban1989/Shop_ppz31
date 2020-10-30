using System;
using System.Collections.Generic;
using System.Text;

namespace Shop_PPZ_31.views
{
    abstract class AbstractMenu
    {
        private bool isDone = false;

        protected abstract void Init();
        protected abstract void Idle();
        protected abstract void CleanUp();

        protected void SetDone()
        {
            isDone = true;
        }

        protected bool Done()
        {
            return isDone;
        }

        public void Run()
        {
            Init();
            while(!Done())
            {
                Idle();
            }
            CleanUp();
        }
    }
}
