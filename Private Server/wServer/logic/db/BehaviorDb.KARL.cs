#region

using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ KARL = () => Behav()
          .Init("Karl Totem",
             new State(
                   new State("init",
                       new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TossObject("Karl Vill", 4, 360, 320000),
                        new TossObject("Karl Vill", 4, 270, 320000),
                        new TossObject("Karl Vill", -4, 270, 320000),
                        new TossObject( "Karl Vill", -4, 360, 320000),
                        new TimedTransition(10000, "checkDead")
                        ),
                  new State("checkDead",
                      new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                      new EntitiesNotExistsTransition(9, "AngryTotem", "Karl Vill")
                        ),
                  new State("AngryTotem",
                      new Shoot(radius: 360, count: 6, projectileIndex: 0, coolDown: 200, angleOffset: 60, coolDownOffset: 150),
                      new Shoot(radius: 360, count: 6, projectileIndex: 0, coolDown: 200, angleOffset: 30)

                        )

                  )
            )
         .Init("Twlight Adept",
                new State(
                    new State("Wait",
                        new PlayerWithinTransition(5, "fire")
                            ),
                    new State("fire",
                        new Follow(0.5, range: 1),
                        new Shoot(10, 7, 10, projectileIndex: 0, coolDown: 1000),
                        new Shoot(10, 6, 10, projectileIndex: 1, coolDown: 1500),
                        new TimedTransition(15000, "PreSpawn")
                        ),
                    new State("PreSpawn",
                        new Follow(0.5, range: 1),
                        new Shoot(10, 7, 10, projectileIndex: 0, coolDown: 1000),
                        new EntityNotExistsTransition("Twlight Adept Ice Shield", 30, "Spawn")
                        ),
                    new State("Spawn",
                        new Spawn("Twlight Adept Ice Shield", maxChildren: 2, initialSpawn: 2, coolDown: 750000000),
                        new TimedTransition(25, "fire")
                        )
                    )
            )

             .Init("Karl Vill", 
                new State(
                    new Prioritize(
                        new Orbit(.5, 3, target: "Karl Totem", radiusVariance: 0.1)
                        ),
                    new Shoot(radius: 60 ,count: 2 , projectileIndex: 0 ,coolDown: 2000, predictive: 1),
                    new Grenade(radius: 5 ,damage: 40 ,range: 15 , coolDown: 3000 )
                    ),
                new ItemLoot("Magic Potion", 0.02),
                new ItemLoot("Spirit Salve Tome", 0.02)
            )


            .Init("Twlight Adept Ice Shield",
                new State(
                    new HpLessTransition(.2, "Death"),
                    new State("Shoot1",
                        new Charge(0.8, 20, coolDown: 3000),
                        new Shoot(3, 6, 60, projectileIndex: 0, fixedAngle: 0, coolDown: 1200),
                        new Shoot(3, 6, 60, projectileIndex: 0, fixedAngle: 10, coolDown: 1200, coolDownOffset: 200),
                        new Shoot(3, 6, 60, projectileIndex: 0, fixedAngle: 20, coolDown: 1200, coolDownOffset: 400),
                        new Shoot(3, 6, 60, projectileIndex: 0, fixedAngle: 30, coolDown: 1200, coolDownOffset: 600),
                        new Shoot(3, 6, 60, projectileIndex: 0, fixedAngle: 40, coolDown: 1200, coolDownOffset: 800),
                        new Shoot(3, 6, 60, projectileIndex: 0, fixedAngle: 50, coolDown: 1200, coolDownOffset: 1000),
                        new TimedTransition(1200, "Shoot2")
                        ),
                    new State("Shoot2",
                        new Shoot(3, 6, 60, projectileIndex: 0, fixedAngle: 0, coolDown: 1200),
                        new Shoot(3, 6, 60, projectileIndex: 0, fixedAngle: 10, coolDown: 1200, coolDownOffset: 200),
                        new Shoot(3, 6, 60, projectileIndex: 0, fixedAngle: 20, coolDown: 1200, coolDownOffset: 400),
                        new Shoot(3, 6, 60, projectileIndex: 0, fixedAngle: 30, coolDown: 1200, coolDownOffset: 600),
                        new Shoot(3, 6, 60, projectileIndex: 0, fixedAngle: 40, coolDown: 1200, coolDownOffset: 800),
                        new Shoot(3, 6, 60, projectileIndex: 0, fixedAngle: 50, coolDown: 1200, coolDownOffset: 1000),
                        new TimedTransition(1200, "Shoot1")
                    ),
                    new State("Death",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(13, 45, 8, projectileIndex: 1, fixedAngle: 1, coolDown: 10000),
                        new Timed(1000, new Suicide())
                    )
                )
            )

                        .Init("Corrupted Archmage",
                new State(
                new State("Main",
                    new TimedTransition(5000, "Throw"),
                    new Follow(0.8, range: 1),
                    new Shoot(10, 4, projectileIndex: 0, coolDown: 100, predictive: 1, fixedAngle: 60),
                    new Shoot(10, 3, projectileIndex: 1, shootAngle: 10, coolDown: 4000, predictive: 1)
                ),
                new State("Throw",
                    new TossObject("Twlight Portal", coolDown: 2000, coolDownOffset: 0),
                    new TimedTransition(1000, "Main")
                )
                  ))

         .Init("Corrupted Swordsman",
                new State(  
                    new Follow(0.8, range: 1),
                    new Shoot(10, 1, projectileIndex: 0, coolDown: 100, predictive: 1),
                    new Shoot(radius: 15, count: 3, projectileIndex: 1, coolDown: 1000, predictive: 1)
                    )
            )
         .Init("Twlight Portal",
                new State(
                    new State("Idle",
                        new TimedTransition(1000, "Spin")
                    ),
                    new State("Spin",
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 0, coolDown: 1200),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 15, coolDown: 600, coolDownOffset: 100),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 30, coolDown: 600, coolDownOffset: 200),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 45, coolDown: 600, coolDownOffset: 300),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 60, coolDown: 600, coolDownOffset: 400),
                            new Shoot(0, projectileIndex: 0, count: 6, shootAngle: 60, fixedAngle: 75, coolDown: 600, coolDownOffset: 500)
                           
                    )

                )
            )








        ;
    }
}