using System.Collections;
using System.Collections.Generic;
using RPG.Movement;
using RPG.Combat;
using UnityEngine;


namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {

        void Update()
        {
            if (InteractWithCombat()) return;
            if (InteractWithMovement()) return;
            

        } //update

        private bool InteractWithCombat() 
        {

            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());

            foreach (RaycastHit hit in hits)
            {
                
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if (target == null) continue;

                if (Input.GetMouseButtonDown(0)) 
                {
                    GetComponent<Fighter>().Attack(target);

                }
                return true;
            }
            return false;

        }

        private bool InteractWithMovement()
        {
            //Ray ray = GetMouseRay(); // ray変数を定義
            RaycastHit hit; // hit変数を定義
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit); // hasHitがtrueの場合rayとhitが発動

            if (hasHit)
            {
                if (Input.GetMouseButton(0)) 
                {
                    GetComponent<Mover>().StartMoveAction(hit.point);
                }
                return true;
            }
            return false;

        } //MoveToCursor

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    } // playerController class

} //namespace RPG.Control










