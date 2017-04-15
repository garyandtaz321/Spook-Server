#region

using wServer.logic.behaviors;
using wServer.logic.loot;
using wServer.logic.transitions;

#endregion

namespace wServer.logic
{
    partial class BehaviorDb
    {
        private _ Oryx = () => Behav()
                .Init("Oryx, Guardian of the Void",
                new State(
                    new RealmPortalDrop(),
                     new State("idle",
                         new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                         new PlayerWithinTransition(12, "announce")
                         ),
                     new State("announce",
                         new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                         new Taunt("You lay your eyes apon Oryx, Guardian of the Void. Leave or be consumed."),
                         new TimedTransition(4000, "Spawn")
                         ),
                         new State("Spawn",
                         new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                         new Taunt("Minions, Come, Come merge these so called Heros with the ever expanding void. "),

                        // new TossObject("Oryx Void Henchmen", 5, coolDown: 1000, randomToss: true),
                        new TossObject("Oryx Void Henchmen", 8, 360, 320000),
                        new TossObject("Oryx Void Henchmen", 8, 270, 320000),
                        new TossObject("Oryx Void Henchmen", -8, 270, 320000),
                        new TossObject("Oryx Void Henchmen", -8, 360, 320000),

                         new TimedTransition(5000, "checkalive")

                         ),
                         new State("checkalive",
                         new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                         new Taunt(1, 8000, "My minions shall turn you into food for Delirous"),
                         new EntitiesNotExistsTransition(9999, "attack", "Oryx Void Henchmen")
                         ),
                    new State("attack",
                        new Wander(.15),
                        new Taunt("I see you are a challenge, many like you have come, yet fallen like the rest."),
                        new Shoot(25, projectileIndex: 0, count: 2, shootAngle: 45, coolDown: 1500, coolDownOffset: 1500),
                        new Shoot(25, projectileIndex: 1, count: 3, shootAngle: 10, coolDown: 1000, coolDownOffset: 1500),
                        new Shoot(25, projectileIndex: 2, count: 3, shootAngle: 10, predictive: 0.2, coolDown: 1250,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 3, count: 3, shootAngle: 10, predictive: 0.4, coolDown: 1250,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 4, count: 3, shootAngle: 10, predictive: 0.6, coolDown: 1250,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 5, count: 2, shootAngle: 10, predictive: 0.8, coolDown: 1250,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 6, count: 3, shootAngle: 10, predictive: 1, coolDown: 1250,
                            coolDownOffset: 1000),
                        new Grenade(4, 100, 4, coolDown: 4000),
                        new Taunt(1, 6000, "Stand back, or be killed"),
                        new HpLessTransition(.6, "DelMalp")
                    ),
                     new State("DelMalp",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                    new ConditionalEffect(ConditionEffectIndex.StunImmune),
                    new Taunt("Delirous. Give ms strength to rid of these pests."),
                        new Taunt( "Malphus, Rid these fools from my domain!"),
                    new TossObject("Archdemon Malphas Void", coolDown: 3000000, coolDownOffset: 0),
                    new TimedTransition(10000, "checkaliveMalp")

                    ),
                      new State("checkaliveMalp",
                          new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                                                  new ConditionalEffect(ConditionEffectIndex.StunImmune),
                          new Taunt(1, 6000, "My minions will keep me alive."),
                          new EntitiesNotExistsTransition(9999, "DelSept", "Archdemon Malphas Void")
                          ),
                     new State("DelSept",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                                            new ConditionalEffect(ConditionEffectIndex.StunImmune),
                    new Taunt("Malphas! You will be avenged fallen brethen!"),
                    new Taunt("Septavis, Create these heros into fallen warriors for your domain."),
                    new TossObject("Septavius the Ghost God Void", coolDown: 3000000, coolDownOffset: 0),
                         new TimedTransition(10000, "checkaliveSept")


                    ),
                    new State("checkaliveSept",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                                                new ConditionalEffect(ConditionEffectIndex.StunImmune),
                        new Taunt(1, 6000, "My minions will keep me alive"),
                                    new EntitiesNotExistsTransition(9999, "DelTerrible", "Septavius the Ghost God Void")
                          ),
                    new State("DelTerrible",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                                            new ConditionalEffect(ConditionEffectIndex.StunImmune),
                    new Taunt("Septavis! Your armies will not go unled."),
                    new Taunt("Dr Terrible, End these abominations lives!"),
                    new TossObject("Dr Terrible Void", coolDown: 3000000, coolDownOffset: 0),
                    new TimedTransition(10000, "checkaliveTerb")


                    ),
                    new State("checkaliveTerb",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                                                new ConditionalEffect(ConditionEffectIndex.StunImmune),
                        new Taunt(1, 6000, "My minions will keep me alive"),
                                    new EntitiesNotExistsTransition(9999, "DelPuppet", "Dr Terrible Void")
                          ),
                    new State("DelPuppet",
                    new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new ConditionalEffect(ConditionEffectIndex.StunImmune),
                    new Taunt("Dr. Terrible, your creations will not go un-fed,"),
                    new Taunt("Puppet Master! Take these heros Essence to build your armies"),
                    new TossObject("The Puppet Master Void", coolDown: 30000000, coolDownOffset: 0),
                    new TimedTransition(10000, "checkalivePup")


                    ),
                    new State("checkalivePup",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new ConditionalEffect(ConditionEffectIndex.StunImmune),

                        new Taunt(1, 6000, "My minions will keep me alive"),
                                    new EntitiesNotExistsTransition(9999, "prepareRage", "The Puppet Master Void")
                          ),

                    new State("prepareRage",
                        new Follow(.1, 15, 3),
                        new Taunt("Fool! You don't understand what lies behind this gate! It will corrupt you as it has corrupt me"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(25, 30, fixedAngle: 0, projectileIndex: 7, coolDown: 1000, coolDownOffset: 4000),
                        new Shoot(25, 30, fixedAngle: 30, projectileIndex: 8, coolDown: 1000, coolDownOffset: 4000),
                        new Heal(1, "Self", 1000),
                        new TimedTransition(5000, "rage")
                    ),
                    new State("rage",
                        new Follow(.1, 15, 3),
                        new Shoot(25, 30, projectileIndex: 7, coolDown: 6000, coolDownOffset: 8000),
                        new Shoot(25, 30, projectileIndex: 8, coolDown: 6000, coolDownOffset: 8500),
                        new Shoot(25, projectileIndex: 0, count: 8, shootAngle: 45, coolDown: 1500, coolDownOffset: 1500),
                        new Shoot(25, projectileIndex: 1, count: 3, shootAngle: 10, coolDown: 1500, coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 2, count: 3, shootAngle: 10, predictive: 0.2, coolDown: 1500,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 3, count: 2, shootAngle: 10, predictive: 0.4, coolDown: 1500,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 4, count: 3, shootAngle: 10, predictive: 0.6, coolDown: 1500,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 5, count: 2, shootAngle: 10, predictive: 0.8, coolDown: 1500,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 6, count: 3, shootAngle: 10, predictive: 1, coolDown: 1500,
                            coolDownOffset: 1000),
                        new Grenade(10, 150, 15, coolDown: 1800),
                        //new TossObject("Monstrosity Scarab", 7, 0, coolDown: 1000, randomToss: true),
                        new Taunt(1, 6000, "You dare CHALLENGE ORYX THE GUARDIAN!"),
                        new HpLessTransition(.07, "Death")
                    ),
                    new State("Explode1",
                        new Orbit(0.3, .1, 10, "Void Anchor 1")

                        ),
                       new State("Explode2",
                             new Orbit(0.3, .1, 10, "Void Anchor 2")

                        ),
                        new State("Explode3",
                                 new Orbit(0.3, .1, 10, "Void Anchor 3")

                        ),
                        new State("Explode4",
                                new Orbit(0.3, .1, 10, "Void Anchor 4")

                        ),
                    new State("Death",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Taunt("You unleash doom upon the realm, I have done all I can, yet I have failed."),

                            new TimedTransition(5000, "Suicide")
                    ),
                    new State("Suicide",
                            new Shoot(35, projectileIndex: 6, count: 60),
                            new Suicide()
                    )
                ),
                new MostDamagers(3,
                    new ItemLoot("Potion of Vitality", 1)
                ),
                new Threshold(0.05,
                    new ItemLoot("Potion of Attack", 0.3),
                    new ItemLoot("Potion of Defense", 0.3),
                    new ItemLoot("Potion of Wisdom", 0.3)
                ),
                new Threshold(0.1,
                    new TierLoot(10, ItemType.Weapon, 0.07),
                    new TierLoot(11, ItemType.Weapon, 0.06),
                    new TierLoot(12, ItemType.Weapon, 0.05),
                    new TierLoot(5, ItemType.Ability, 0.07),
                    new TierLoot(6, ItemType.Ability, 0.05),
                    new TierLoot(11, ItemType.Armor, 0.07),
                    new TierLoot(12, ItemType.Armor, 0.06),
                    new TierLoot(13, ItemType.Armor, 0.05),
                    new TierLoot(5, ItemType.Ring, 0.06)
                )
            )
        // Void Start
                 .Init("Void Anchor 1",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible)
                )
                )
                 .Init("Void Anchor 2",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible)
                )
                )
                 .Init("Void Anchor 3",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible)
                )
                )
                 .Init("Void Anchor 4",
            new State(
                new ConditionalEffect(ConditionEffectIndex.Invincible)
                )
                )

        .Init("Dr Terrible Void",
            new State(
                new State("spawn",
                    new Follow(.1, 15, 3),
                            new Taunt("New minions to test within the void? Perfect!"),
                            new Taunt(3 , 5000 ,"My potions shall end you! HueHueHueHue"),
                            new TossObject("Green Potion", coolDown: 1500, coolDownOffset: 0),
                            new HpLessTransition(.8, "rage")
                    ),
                new State("rage",
                    new Follow(.6, 15, 3),
                    new Taunt(3, 5000, "You shall Die."),
                    new TossObject("Green Potion", coolDown: 70, coolDownOffset: 0),
                    new TossObject("Green Potion", coolDown: 50, coolDownOffset: 0),
                           new TossObject("Green Potion", 2, 360, 2000),
                        new TossObject("Green Potion", 3, 340, 2000),
                        new TossObject("Green Potion", 2, 320, 2000),
                        new TossObject("Green Potion", 3, 300, 2000),
                        new TossObject("Green Potion", 2, 280, 2000),
                        new TossObject("Green Potion", 3, 260, 2000),
                        new TossObject("Green Potion", 2, 240, 2000),
                         new TossObject("Green Potion", 3, 220, 2000),
                         new TossObject("Green Potion", 2, 200, 2000),
                         new TossObject("Green Potion", 3, 180, 2000),
                        new TossObject("Green Potion", 2, 160, 2000),
                        new TossObject("Green Potion", 3, 140, 2000),
                        new TossObject("Green Potion", 2, 120, 2000),
                        new TossObject("Green Potion", 3, 100, 2000),
                        new TossObject("Green Potion", 2, 80, 2000),
                        new TossObject("Green Potion", 3, 60, 2000),
                        new TossObject("Green Potion", 2, 40, 2000),
                     new TossObject("Green Potion", 2, 20, 2000),
                     new TossObject("Green Potion", 3, 0, 2000),
                    new TossObject("Green Potion", 3, 270, 2000),
                    new HpLessTransition(.05, "Death")
                    ),
                            new State("Death",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Taunt("Freedom from the corruption of delirus, Thank you brave heros."),

                            new TimedTransition(5000, "Suicide")
                    ),
                    new State("Suicide",
                        new TossObject("Green Potion", coolDown: 50, coolDownOffset: 0),
                        new TossObject("Green Potion", coolDown: 50, coolDownOffset: 0),
                        new TossObject("Green Potion", coolDown: 50, coolDownOffset: 0),
                        new TossObject("Green Potion", coolDown: 50, coolDownOffset: 0),
                        new TossObject("Green Potion", coolDown: 50, coolDownOffset: 0),
                        new TossObject("Green Potion", coolDown: 50, coolDownOffset: 0),
                        new TossObject("Green Potion", coolDown: 50, coolDownOffset: 0),
                        new TossObject("Green Potion", coolDown: 50, coolDownOffset: 0),
                        new TossObject("Green Potion", coolDown: 50, coolDownOffset: 0),
                        new TossObject("Green Potion", coolDown: 50, coolDownOffset: 0),
                        new TossObject("Green Potion", coolDown: 50, coolDownOffset: 0),
                        new TossObject("Green Potion", coolDown: 50, coolDownOffset: 0),
                        new TossObject("Green Potion", coolDown: 50, coolDownOffset: 0),
                        new TossObject("Green Potion", coolDown: 50, coolDownOffset: 0),
                        new TossObject("Green Potion", coolDown: 50, coolDownOffset: 0),
                        new TossObject("Green Potion", coolDown: 50, coolDownOffset: 0),
                        new TossObject("Green Potion", coolDown: 50, coolDownOffset: 0),
                        new TossObject("Green Potion", coolDown: 50, coolDownOffset: 0),
                        new TossObject("Green Potion", coolDown: 50, coolDownOffset: 0),
                            new Suicide()
                    )
                )
            )

        .Init("Septavius the Ghost God Void",
                new State(
                    new State("spawn",
                        new Follow(.1, 15, 3),
                        new Taunt("You have made a great mistake entering, you shall now die."),
                        new Shoot(10, 3, fixedAngle: 0, coolDownOffset: 0, coolDown: 1000),
                        new Shoot(10, 3, fixedAngle: 24, coolDownOffset: 200, coolDown: 1000),
                        new Shoot(10, 3, fixedAngle: 48, coolDownOffset: 400, coolDown: 1000),
                        new Shoot(10, 3, fixedAngle: 72, coolDownOffset: 600, coolDown: 1000),
                        new Shoot(10, 3, fixedAngle: 96, coolDownOffset: 800, coolDown: 1000),
                        new Shoot(10, 3, fixedAngle: 118, coolDownOffset: 200, coolDown: 1000),
                        new Shoot(10, 3, fixedAngle: 142, coolDownOffset: 400, coolDown: 1000),
                        new Shoot(10, 3, fixedAngle: 166, coolDownOffset: 600, coolDown: 1000),
                        new Shoot(10, 3, fixedAngle: 190, coolDownOffset: 800, coolDown: 1000),
                       new HpLessTransition(.8, "ring")
                        ),
                    new State("ring",
                        new Wander(0.1),
                        new Shoot(10, 12, projectileIndex: 4, coolDown: 1000),
                            new HpLessTransition(.8, "rage")
                        ),
                    new State("quiet",
                        new Wander(0.1),
                        new Shoot(10, 8, projectileIndex: 1, coolDown: 1000),
                        new Shoot(10, 8, projectileIndex: 1, coolDownOffset: 500, angleOffset: 22.5, coolDown: 1000),
                        new Shoot(8, 3, shootAngle: 20, projectileIndex: 2, coolDown: 2000),
                        new HpLessTransition(.5, "rage")
                        ),
                    new State("rage",
                        new Follow(.6, 15, 3),
                        new Taunt("YOU SHALL PAY FOR THE CORRRUPTION YOU BROUGHT APON THIS REALM"),
                        new Shoot(8, 5, shootAngle: 20, projectileIndex: 2, coolDown: 500),
                        new Shoot(10, 8, projectileIndex: 1, coolDownOffset: 500, angleOffset: 22.5, coolDown: 500),
                        new Shoot(10, 3, fixedAngle: 0, coolDownOffset: 0, coolDown: 500),
                        new Shoot(10, 3, fixedAngle: 24, coolDownOffset: 200, coolDown: 500),
                        new Shoot(10, 3, fixedAngle: 48, coolDownOffset: 400, coolDown: 500),
                        new Shoot(10, 3, fixedAngle: 72, coolDownOffset: 600, coolDown: 500),
                        new Shoot(10, 3, fixedAngle: 96, coolDownOffset: 800, coolDown: 500),
                        new Shoot(10, 3, fixedAngle: 118, coolDownOffset: 200, coolDown: 500),
                        new Shoot(10, 3, fixedAngle: 142, coolDownOffset: 400, coolDown: 500),
                        new Shoot(10, 3, fixedAngle: 166, coolDownOffset: 600, coolDown: 500),
                        new Shoot(10, 3, fixedAngle: 190, coolDownOffset: 800, coolDown: 500),
                        new Shoot(10, 3, fixedAngle: 214, coolDownOffset: 0, coolDown: 500),
                        new Shoot(10, 3, fixedAngle: 238, coolDownOffset: 200, coolDown: 500),
                        new Shoot(10, 3, fixedAngle: 262, coolDownOffset: 400, coolDown: 500),
                        new Shoot(10, 3, fixedAngle: 286, coolDownOffset: 600, coolDown: 500),
                        new Shoot(10, 3, fixedAngle: 310, coolDownOffset: 800, coolDown: 500),
                        new Shoot(10, 3, fixedAngle: 334, coolDownOffset: 200, coolDown: 500),
                        new Shoot(10, 3, fixedAngle: 358, coolDownOffset: 400, coolDown: 500),
                        new Shoot(10, 20, projectileIndex: 4, coolDown: 100),
                       new HpLessTransition(.1, "Death")
                        ),
                     new State("Death",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Taunt("Free, Free from the curse, thank you.. hero"),

                            new TimedTransition(5000, "Suicide")
                    ),
                    new State("Suicide",
                            new Suicide()
                    )
                ),
                new Threshold(0.32, /* Maximum 3 wis, minimum 0 wis */
                    new ItemLoot("Potion of Wisdom", 1)
                ),
                new Threshold(0.1,
                    new ItemLoot("Doom Bow", 0.012),
                    new ItemLoot("Wine Cellar Incantation", 0.005),
                    new TierLoot(3, ItemType.Ring, 0.2),
                    new TierLoot(4, ItemType.Ring, 0.1),
                    new TierLoot(7, ItemType.Weapon, 0.2),
                    new TierLoot(8, ItemType.Weapon, 0.1),
                    new TierLoot(3, ItemType.Ability, 0.2),
                    new TierLoot(4, ItemType.Ability, 0.15),
                    new TierLoot(5, ItemType.Ability, 0.1)
                ),
                new Threshold(0.2
                )
            )


 .Init("The Puppet Master Void",
                new State(
                     new State("start",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Taunt(1.00, "Hello so called 'heros'. I will merge you with the void to empower our cause"),
                        new TimedTransition(5250, "middleShots")
                        ),
                    new State("middleShots",
                        new Taunt(1.00, "Prepare to be Destroyed."),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 2450, fixedAngle: 160, coolDownOffset: 1400, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 2450, fixedAngle: 170, coolDownOffset: 1600, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 2450, fixedAngle: 180, coolDownOffset: 1800, shootAngle: 90),
                            new Shoot(2, 8, projectileIndex: 3, coolDown: 2450, fixedAngle: 180, coolDownOffset: 2000, shootAngle: 45),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 2450, fixedAngle: 180, coolDownOffset: 0, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 2450, fixedAngle: 170, coolDownOffset: 200, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 2450, fixedAngle: 160, coolDownOffset: 400, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 2450, fixedAngle: 150, coolDownOffset: 600, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 2450, fixedAngle: 140, coolDownOffset: 800, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 2450, fixedAngle: 130, coolDownOffset: 1000, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 2450, fixedAngle: 290, coolDownOffset: 1200, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 2450, fixedAngle: 278, coolDownOffset: 1400, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 2450, fixedAngle: 100, coolDownOffset: 1600, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 2450, fixedAngle: 38, coolDownOffset: 1400, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 2450, fixedAngle: 47, coolDownOffset: 1600, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 2450, fixedAngle: 23, coolDownOffset: 1800, shootAngle: 90),
                            new Shoot(2, 8, projectileIndex: 3, coolDown: 2450, fixedAngle: 267, coolDownOffset: 2000, shootAngle: 45),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 2450, fixedAngle: 342, coolDownOffset: 0, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 2450, fixedAngle: 256, coolDownOffset: 200, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 2450, fixedAngle: 234, coolDownOffset: 400, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 2450, fixedAngle: 216, coolDownOffset: 600, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 2450, fixedAngle: 197, coolDownOffset: 800, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 2450, fixedAngle: 167, coolDownOffset: 1000, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 2450, fixedAngle: 145, coolDownOffset: 1200, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 2450, fixedAngle: 134, coolDownOffset: 1400, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 2450, fixedAngle: 56, coolDownOffset: 1600, shootAngle: 90),
                         new HpLessTransition(.8, "sadTime")
                        ),
                    new State("sadTime",
                        new Taunt(1.00, "You shall soon be one with the void"),
                        new Follow(0.34, 8, 5),
                        new Shoot(10, projectileIndex: 2, predictive: 0.5, coolDown: 200),
                        new TimedTransition(6000, "customspiral")
                        ),
                    new State("customspiral",
                        new Shoot(1, 4, projectileIndex: 3, coolDown: 300, fixedAngle: 90, coolDownOffset: 0, shootAngle: 90),
                        new Shoot(1, 4, projectileIndex: 3, coolDown: 300, fixedAngle: 100, coolDownOffset: 200, shootAngle: 90),
                        new Shoot(1, 4, projectileIndex: 3, coolDown: 300, fixedAngle: 110, coolDownOffset: 400, shootAngle: 90),
                        new Shoot(1, 4, projectileIndex: 3, coolDown: 300, fixedAngle: 120, coolDownOffset: 600, shootAngle: 90),
                        new Shoot(8.4, count: 1, fixedAngle: 0, projectileIndex: 0, coolDown: 1000),
                        new Shoot(8.4, count: 1, fixedAngle: 90, projectileIndex: 0, coolDown: 2500),
                        new Shoot(8.4, count: 1, fixedAngle: 180, projectileIndex: 0, coolDown: 2500),
                        new Shoot(8.4, count: 1, fixedAngle: 270, projectileIndex: 0, coolDown: 2500),
                        new Shoot(8.4, count: 1, fixedAngle: 45, projectileIndex: 0, coolDown: 2500),
                        new Shoot(8.4, count: 1, fixedAngle: 135, projectileIndex: 0, coolDown: 1000),
                        new Shoot(8.4, count: 1, fixedAngle: 235, projectileIndex: 0, coolDown: 1000),
                        new Shoot(8.4, count: 1, fixedAngle: 315, projectileIndex: 0, coolDown: 1000),
                        new Shoot(1, 4, projectileIndex: 3, coolDown: 300, fixedAngle: 90, coolDownOffset: 0, shootAngle: 90),
                        new Shoot(1, 4, projectileIndex: 3, coolDown: 300, fixedAngle: 100, coolDownOffset: 200, shootAngle: 90),
                        new Shoot(1, 4, projectileIndex: 3, coolDown: 300, fixedAngle: 110, coolDownOffset: 400, shootAngle: 90),
                        new Shoot(1, 4, projectileIndex: 3, coolDown: 300, fixedAngle: 120, coolDownOffset: 600, shootAngle: 90),
                        new Shoot(8.4, count: 1, fixedAngle: 0, projectileIndex: 0, coolDown: 1000),
                        new Shoot(8.4, count: 1, fixedAngle: 90, projectileIndex: 0, coolDown: 2500),
                        new Shoot(8.4, count: 1, fixedAngle: 180, projectileIndex: 0, coolDown: 2500),
                        new Shoot(8.4, count: 1, fixedAngle: 270, projectileIndex: 0, coolDown: 2500),
                        new Shoot(8.4, count: 1, fixedAngle: 45, projectileIndex: 0, coolDown: 2500),
                        new Shoot(8.4, count: 1, fixedAngle: 135, projectileIndex: 0, coolDown: 1000),
                        new Shoot(8.4, count: 1, fixedAngle: 235, projectileIndex: 0, coolDown: 1000),
                        new Shoot(8.4, count: 1, fixedAngle: 315, projectileIndex: 0, coolDown: 1000),
                        new HpLessTransition(.3, "Rage")
                        ),
                  
                   new State("Rage",
                       new Heal(.7, "Self", 1000000000),
                        new Taunt("DO YOU NOT SEE, I AM TRYING TO SAVE YOU FROM A WORSE FATE! RUN HERO BEFORE I LOSE CONTROL"),
                        new Taunt(3,3000, "DIE"),
                        new Follow(.5, range: 2),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 1000, fixedAngle: 160, coolDownOffset: 1400, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 1000, fixedAngle: 170, coolDownOffset: 1600, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 1000, fixedAngle: 180, coolDownOffset: 1800, shootAngle: 90),
                            new Shoot(2, 8, projectileIndex: 3, coolDown: 1000, fixedAngle: 180, coolDownOffset: 2000, shootAngle: 45),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 1000, fixedAngle: 180, coolDownOffset: 0, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 1000, fixedAngle: 170, coolDownOffset: 200, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 1000, fixedAngle: 160, coolDownOffset: 400, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 1000, fixedAngle: 150, coolDownOffset: 600, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 1000, fixedAngle: 140, coolDownOffset: 800, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 1000, fixedAngle: 130, coolDownOffset: 1000, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 1000, fixedAngle: 290, coolDownOffset: 1200, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 1000, fixedAngle: 278, coolDownOffset: 1400, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 1000, fixedAngle: 100, coolDownOffset: 1600, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 1000, fixedAngle: 38, coolDownOffset: 1400, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 1000, fixedAngle: 47, coolDownOffset: 1600, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 1000, fixedAngle: 23, coolDownOffset: 1800, shootAngle: 90),
                            new Shoot(2, 8, projectileIndex: 3, coolDown: 1000, fixedAngle: 267, coolDownOffset: 2000, shootAngle: 45),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 1000, fixedAngle: 342, coolDownOffset: 0, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 1000, fixedAngle: 256, coolDownOffset: 200, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 1000, fixedAngle: 234, coolDownOffset: 400, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 1000, fixedAngle: 216, coolDownOffset: 600, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 1000, fixedAngle: 197, coolDownOffset: 800, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 1000, fixedAngle: 167, coolDownOffset: 1000, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 1000, fixedAngle: 145, coolDownOffset: 1200, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 1000, fixedAngle: 134, coolDownOffset: 1400, shootAngle: 90),
                            new Shoot(2, 4, projectileIndex: 3, coolDown: 1000, fixedAngle: 56, coolDownOffset: 1600, shootAngle: 90),
                            new Shoot(7, count: 25, projectileIndex: 1, coolDown: 4500),
                            new Shoot(7, count: 25, projectileIndex: 3, coolDown: 4500),
                         new HpLessTransition(.1, "NopeImDead")
                        ),
                    new State("NopeImDead",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Flash(0xFFFFFF, 2, 2),
                        new Taunt(1.00, "Freedom, freedom from the void. Thank you heros."),
                        new TimedTransition(3250, "YepDead")
                        ),
                   new State("YepDead",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(7, count: 60, projectileIndex: 1, coolDown: 5000),
                        new Suicide()
                        )
                 )
            )


         .Init("Archdemon Malphas Void",
                new State(
                    new State("Active",
                        new Taunt("You are fools for entering into the void's domain, and you shall be punished."),
                         new TimedTransition(2000, "basic")
                        ),
                    new State("basic",
                        new Prioritize(
                            new Follow(0.3),
                            new Wander(0.2)
                            ),
                        new Reproduce("Malphas Missile", densityMax: 1, spawnRadius: 1, coolDown: 300),
                        new Shoot(10, count: 4, predictive: 1, coolDown: 800),
                        new TimedTransition(10000, "shrink")
                        ),
                    new State("shrink",
                        new Wander(0.4),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new ChangeSize(-15, 25),
                        new TimedTransition(1000, "smallAttack")
                        ),
                    new State("smallAttack",
                        new Prioritize(
                            new Follow(1, acquireRange: 15, range: 8),
                            new Wander(1)
                            ),
                        new Shoot(10, count: 7, predictive: 1, coolDown: 750),
                        new Shoot(10, 6, projectileIndex: 1, predictive: 1, coolDown: 1000),
                        new TimedTransition(10000, "grow")
                        ),
                    new State("grow",
                        new Wander(0.1),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new ChangeSize(35, 200),
                        new TimedTransition(1050, "bigAttack")
                        ),
                    new State("bigAttack",
                        new Prioritize(
                            new Follow(0.2),
                            new Wander(0.1)
                            ),
                        new Shoot(10, projectileIndex: 2, predictive: 1, coolDown: 2000),
                        new Shoot(10, projectileIndex: 2, predictive: 1, coolDownOffset: 300, coolDown: 2000),
                        new Shoot(10, 3, projectileIndex: 3, predictive: 1, coolDownOffset: 100, coolDown: 2000),
                        new Shoot(10, 3, projectileIndex: 3, predictive: 1, coolDownOffset: 400, coolDown: 2000),
                        new TimedTransition(10000, "normalize")
                        ),
                    new State("normalize",
                        new Wander(0.3),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new ChangeSize(-20, 100),
                        new TimedTransition(1000, "basic")
                        )
                    ),
                //LootTemplates.DefaultEggLoot(EggRarity.Legendary),
                new MostDamagers(3,
                    new ItemLoot("Potion of Vitality", 1.0)
                ),
                new MostDamagers(1,
                    new ItemLoot("Potion of Defense", 1.0)
                ),
                new Threshold(0.025,
                    new TierLoot(9, ItemType.Weapon, 0.1),
                    new TierLoot(4, ItemType.Ability, 0.1),
                    new TierLoot(9, ItemType.Armor, 0.1),
                    new TierLoot(3, ItemType.Ring, 0.05),
                    new TierLoot(10, ItemType.Armor, 0.05),
                    new TierLoot(10, ItemType.Weapon, 0.05),
                    new TierLoot(4, ItemType.Ring, 0.025),
                    new ItemLoot("Demon Blade", 0.01)
                )
            )
            
                            .Init("Oryx Void Henchmen",
                new State(
                         new State("announce",
                         new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                         new ApplySetpiece("VoidHench"),
                         new Taunt( "Assemble! Guard the Gate!"),
                         new TimedTransition(4000, "guard")
                         ),
                           new State( "guard",
                        new Orbit(.5, 3, target: "Oryx, Guardian of the Void", radiusVariance: 0.1),
                    new Shoot(8, projectileIndex: 0, predictive: 1, coolDown: 1500),
                    new Shoot(8, projectileIndex: 1, count: 3, shootAngle: 20, coolDown: 1500, coolDownOffset: 50),
                               new HpLessTransition(.8, "Activate")
                        ),
                         new State("Activate",


                         new Taunt("Attack! Don't let them open the rift!"),
                         new Follow(.5, range: 1),
                    new Shoot(6, projectileIndex: 2, count: 3, shootAngle: 20, coolDown: 500, coolDownOffset: 50),
                    new Shoot(3, projectileIndex: 3, predictive: 1, coolDown: 1500),
                    new Shoot(6, projectileIndex: 4, count: 2, shootAngle: 20, coolDown: 1500, coolDownOffset: 50),
                    new Shoot(6, projectileIndex: 5, count: 1, shootAngle: 20, coolDown: 2000, coolDownOffset: 325),
                    new Shoot(6, projectileIndex: 6, count: 1, shootAngle: 20, predictive: 1, coolDown: 1500, coolDownOffset: 150),
                    new Shoot(6, projectileIndex: 7, count: 2, predictive: 1, shootAngle: 20, coolDown: 2000, coolDownOffset: 300),
                    new Shoot(6, projectileIndex: 8, count: 1, shootAngle: 20, coolDown: 1500, coolDownOffset: 400),
                    new HpLessTransition(.2, "Rage")


                         ),
                    new State("Rage",

                        new ConditionalEffect(ConditionEffectIndex.Armored),
                         new Taunt("FOOLS, YOU DO NOT UNDERSTAND!"),
                         new Heal(.6, "Self", 1000000),
                         new Follow(1.5, range: 1),
                    new Shoot(6, projectileIndex: 2, count: 3, shootAngle: 20, coolDown: 500, coolDownOffset: 50),
                    new Shoot(3, projectileIndex: 3, predictive: 1, coolDown: 1500),
                    new Shoot(6, projectileIndex: 4, count: 2, shootAngle: 20, coolDown: 1500, coolDownOffset: 50),
                    new Shoot(6, projectileIndex: 5, count: 1, shootAngle: 20, coolDown: 2000, coolDownOffset: 325),
                    new Shoot(6, projectileIndex: 6, count: 1, shootAngle: 20, predictive: 1, coolDown: 1500, coolDownOffset: 150),
                    new Shoot(6, projectileIndex: 7, count: 2, predictive: 1, shootAngle: 20, coolDown: 2000, coolDownOffset: 300),
                    new Shoot(6, projectileIndex: 8, count: 1, shootAngle: 20, coolDown: 1500, coolDownOffset: 400),
                    new Shoot(35, projectileIndex: 4, count: 10, coolDown: 6000),
                    new HpLessTransition(.1 , "Death")


                         ),
                    new State("Death",
                            new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                            new Taunt("Brothers... Avenge me and kill these forbidden guests!"),

                            new TimedTransition(5000, "Suicide")
                    ),
                    new State("Suicide",
                            new Shoot(35, projectileIndex:4, count: 10),
                            new Suicide()
                    )


                    )
            )



        // Void End

            .Init("Oryx the Mad God 2",
                new State(
                    new DropPortalOnDeath("Locked Wisiki Cellar Portal", 100, PortalDespawnTimeSec: 120),
                    new State("Attack",
                        new Wander(.05),
                        new Shoot(25, projectileIndex: 0, count: 8, shootAngle: 45, coolDown: 1500, coolDownOffset: 1500),
                        new Shoot(25, projectileIndex: 1, count: 3, shootAngle: 10, coolDown: 1000, coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 2, count: 3, shootAngle: 10, predictive: 0.2, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 3, count: 2, shootAngle: 10, predictive: 0.4, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 4, count: 3, shootAngle: 10, predictive: 0.6, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 5, count: 2, shootAngle: 10, predictive: 0.8, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 6, count: 3, shootAngle: 10, predictive: 1, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Taunt(1, 6000, "Puny mortals! My {HP} HP will annihilate you!"),
                        new Spawn("Henchman of Oryx", 5, coolDown: 5000),
                        new HpLessTransition(.2, "prepareRage")
                    ),
                    new State("prepareRage",
                        new Follow(.1, 15, 3),
                        new Taunt("Can't... keep... henchmen... alive... anymore! ARGHHH!!!"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(25, 30, fixedAngle: 0, projectileIndex: 7, coolDown: 4000, coolDownOffset: 4000),
                        new Shoot(25, 30, fixedAngle: 30, projectileIndex: 8, coolDown: 4000, coolDownOffset: 4000),
                        new TimedTransition(10000, "rage")
                    ),
                    new State("rage",
                        new Follow(.1, 15, 3),
                        new Shoot(25, 30, projectileIndex: 7, coolDown: 90000001, coolDownOffset: 8000),
                        new Shoot(25, 30, projectileIndex: 8, coolDown: 90000001, coolDownOffset: 8500),
                        new Shoot(25, projectileIndex: 0, count: 8, shootAngle: 45, coolDown: 1500, coolDownOffset: 1500),
                        new Shoot(25, projectileIndex: 1, count: 3, shootAngle: 10, coolDown: 1000, coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 2, count: 3, shootAngle: 10, predictive: 0.2, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 3, count: 2, shootAngle: 10, predictive: 0.4, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 4, count: 3, shootAngle: 10, predictive: 0.6, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 5, count: 2, shootAngle: 10, predictive: 0.8, coolDown: 1000,
                            coolDownOffset: 1000),
                        new Shoot(25, projectileIndex: 6, count: 3, shootAngle: 10, predictive: 1, coolDown: 1000,
                            coolDownOffset: 1000),
                        //new TossObject("Monstrosity Scarab", 7, 0, coolDown: 1000, randomToss: true),
                        new Taunt(1, 6000, "Puny mortals! My {HP} HP will annihilate you!")
                    )
                ),
                new MostDamagers(3,
                    new ItemLoot("Potion of Vitality", 1)
                ),
                new Threshold(0.05,
                    new ItemLoot("Potion of Attack", 0.3),
                    new ItemLoot("Potion of Defense", 0.3),
                    new ItemLoot("Potion of Wisdom", 0.3)
                ),
                new Threshold(0.1,
                    new TierLoot(10, ItemType.Weapon, 0.07),
                    new TierLoot(11, ItemType.Weapon, 0.06),
                    new TierLoot(12, ItemType.Weapon, 0.05),
                    new TierLoot(5, ItemType.Ability, 0.07),
                    new TierLoot(6, ItemType.Ability, 0.05),
                    new TierLoot(11, ItemType.Armor, 0.07),
                    new TierLoot(12, ItemType.Armor, 0.06),
                    new TierLoot(13, ItemType.Armor, 0.05),
                    new TierLoot(5, ItemType.Ring, 0.06)
                )
            )
            .Init("Henchman of Oryx",
                new State(
                    new Prioritize(
                        new Orbit(.1, 1, target: "Oryx the Mad God 2", radiusVariance: 0.5),
                        new Follow(.2, 8, 3, coolDown: 0)
                        ),
                    new Shoot(8, projectileIndex: 0, predictive: 1, coolDown: 1500),
                    new Shoot(8, projectileIndex: 1, count: 3, shootAngle: 20, coolDown: 1500, coolDownOffset: 500)
                    )
            )

            .Init("Monstrosity Scarab",
                new State(
                    new State("searching",
                        new Prioritize(
                            new Follow(2, range: 0)
                            ),
                        new PlayerWithinTransition(2, "creeping"),
                        new TimedTransition(5000, "creeping")
                        ),
                    new State("creeping",
                        new Shoot(2, 10, 36, fixedAngle: 0),
                        new Decay(0)
                        )
                    )
            )
            .Init("Oryx the Mad God 1",
                new State(
                    new DropPortalOnDeath("Locked Wine Cellar Portal", 100, PortalDespawnTimeSec: 120),
                    new HpLessTransition(.2, "rage"),
                    new State("Slow",
                        new Taunt("Fools! I still have {HP} hitpoints!"),
                        new Spawn("Minion of Oryx", 5, 0, 350000),
                        new Reproduce("Minion of Oryx", 10, 5, 1500),
                        new Shoot(25, 4, 10, 4, coolDown: 1000),
                        new TimedTransition(20000, "Dance 1")
                        ),
                    new State("Dance 1",
                        new Flash(0xf389E13, 0.5, 60),
                        new Taunt("BE SILENT!!!"),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(50, 8, projectileIndex: 6, coolDown: 700, coolDownOffset: 200),
                        new TossObject("Ring Element", 9, 24, 320000),
                        new TossObject("Ring Element", 9, 48, 320000),
                        new TossObject("Ring Element", 9, 72, 320000),
                        new TossObject("Ring Element", 9, 96, 320000),
                        new TossObject("Ring Element", 9, 120, 320000),
                        new TossObject("Ring Element", 9, 144, 320000),
                        new TossObject("Ring Element", 9, 168, 320000),
                        new TossObject("Ring Element", 9, 192, 320000),
                        new TossObject("Ring Element", 9, 216, 320000),
                        new TossObject("Ring Element", 9, 240, 320000),
                        new TossObject("Ring Element", 9, 264, 320000),
                        new TossObject("Ring Element", 9, 288, 320000),
                        new TossObject("Ring Element", 9, 312, 320000),
                        new TossObject("Ring Element", 9, 336, 320000),
                        new TossObject("Ring Element", 9, 360, 320000),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        //new Grenade(radius: 4, damage: 150, fixedAngle: new Random().Next(0, 359), range: 5, coolDown: 2000),
                        //new Grenade(radius: 4, damage: 150, fixedAngle: new Random().Next(0, 359), range: 5, coolDown: 2000),
                        //new Grenade(radius: 4, damage: 150, fixedAngle: new Random().Next(0, 359), range: 5, coolDown: 2000),
                        new TimedTransition(25000, "artifacts")
                        ),
                    new State("artifacts",
                        new Taunt("My Artifacts will protect me!"),
                        new Flash(0xf389E13, 0.5, 60),
                        new Shoot(50, 3, projectileIndex: 9, coolDown: 1500, coolDownOffset: 200),
                        new Shoot(50, 10, projectileIndex: 8, coolDown: 2000, coolDownOffset: 200),
                        new Shoot(50, 10, projectileIndex: 7, coolDown: 500, coolDownOffset: 200),

                        //Inner Elements
                        new TossObject("Guardian Element 1", 1, 0, 90000001, 1000),
                        new TossObject("Guardian Element 1", 1, 90, 90000001, 1000),
                        new TossObject("Guardian Element 1", 1, 180, 90000001, 1000),
                        new TossObject("Guardian Element 1", 1, 270, 90000001, 1000),
                        new TossObject("Guardian Element 2", 9, 0, 90000001, 1000),
                        new TossObject("Guardian Element 2", 9, 90, 90000001, 1000),
                        new TossObject("Guardian Element 2", 9, 180, 90000001, 1000),
                        new TossObject("Guardian Element 2", 9, 270, 90000001, 1000),
                        new TimedTransition(25000, "gaze")
                        ),

                    #region gaze
                    new State("gaze",
                        new Taunt("All who looks upon my face shall die."),
                        new Shoot(count: 2, coolDown: 1000, projectileIndex: 1, radius: 7, shootAngle: 10,
                            coolDownOffset: 800),
                        new TimedTransition(10000, "Dance 2")
                        #endregion gaze

                        ),

                    #region Dance 2
                    new State("Dance 2",
                        new Flash(0xf389E13, 0.5, 60),
                        new Taunt("Time for more dancing!"),
                        new Shoot(50, 8, projectileIndex: 6, coolDown: 700, coolDownOffset: 200),
                        new TossObject("Ring Element", 9, 24, 320000),
                        new TossObject("Ring Element", 9, 48, 320000),
                        new TossObject("Ring Element", 9, 72, 320000),
                        new TossObject("Ring Element", 9, 96, 320000),
                        new TossObject("Ring Element", 9, 120, 320000),
                        new TossObject("Ring Element", 9, 144, 320000),
                        new TossObject("Ring Element", 9, 168, 320000),
                        new TossObject("Ring Element", 9, 192, 320000),
                        new TossObject("Ring Element", 9, 216, 320000),
                        new TossObject("Ring Element", 9, 240, 320000),
                        new TossObject("Ring Element", 9, 264, 320000),
                        new TossObject("Ring Element", 9, 288, 320000),
                        new TossObject("Ring Element", 9, 312, 320000),
                        new TossObject("Ring Element", 9, 336, 320000),
                        new TossObject("Ring Element", 9, 360, 320000),
                        new TimedTransition(1000, "Dance2, 1")
                        ),
                    new State("Dance2, 1",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(0, projectileIndex: 8, count: 4, shootAngle: 90, fixedAngle: 0, coolDown: 170),
                        new TimedTransition(200, "Dance2, 2")
                        ),
                    new State("Dance2, 2",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(0, projectileIndex: 8, count: 4, shootAngle: 90, fixedAngle: 30, coolDown: 170),
                        new TimedTransition(200, "Dance2, 3")
                        ),
                    new State("Dance2, 3",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(0, projectileIndex: 8, count: 4, shootAngle: 90, fixedAngle: 15, coolDown: 170),
                        new TimedTransition(200, "Dance2, 4")
                        ),
                    new State("Dance2, 4",
                        new Shoot(0, projectileIndex: 8, count: 4, shootAngle: 90, fixedAngle: 45, coolDown: 170),
                        new TimedTransition(200, "Dance2, 1")
                        ),

                    #endregion Dance 2
                    new State("rage",
                        new ChangeSize(10, 200),
                        new Taunt(.3, "I HAVE HAD ENOUGH OF YOU!!!",
                            "ENOUGH!!!",
                            "DIE!!!"),
                        new Spawn("Minion of Oryx", 10, 0, 350000),
                        new Reproduce("Minion of Oryx", 10, 5, 1500),
                        new Shoot(count: 2, coolDown: 1500, projectileIndex: 1, radius: 7, shootAngle: 10,
                            coolDownOffset: 2000),
                        new Shoot(count: 5, coolDown: 1500, projectileIndex: 16, radius: 7, shootAngle: 10,
                            coolDownOffset: 2000),
                        new Follow(0.85, range: 1, coolDown: 0),
                        new Flash(0xfFF0000, 0.5, 9000001)
                        )
                    )
            )
            .Init("Ring Element",
                new State(
                    new State(
                        new Shoot(50, 12, projectileIndex: 0, coolDown: 700, coolDownOffset: 200),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new TimedTransition(20000, "Despawn")
                        ),
                    new State("Despawn", //new Decay(time:0)
                        new Suicide()
                        )
                    )
            )
            .Init("Minion of Oryx",
                new State(
                    new Wander(0.4),
                    new Shoot(3, 3, 10, 0, coolDown: 1000),
                    new Shoot(3, 3, projectileIndex: 1, shootAngle: 10, coolDown: 1000)
                    ),
                new TierLoot(7, ItemType.Weapon, 0.2),
                new ItemLoot("Health Potion", 0.03)
            )
            .Init("Guardian Element 1",
                new State(
                    new State(
                        new Orbit(1, 1, target: "Oryx the Mad God 1", radiusVariance: 0),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(25, 3, 10, 0, coolDown: 1000),
                        new TimedTransition(10000, "Grow")
                        ),
                    new State("Grow",
                        new ChangeSize(100, 200),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Orbit(1, 1, target: "Oryx the Mad God 1", radiusVariance: 0),
                        new Shoot(3, 1, 10, 0, coolDown: 700),
                        new TimedTransition(10000, "Despawn")
                        ),
                    new State("Despawn",
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Orbit(1, 1, target: "Oryx the Mad God 1", radiusVariance: 0),
                        new ChangeSize(100, 100),
                        new Suicide()
                        )
                    )
            )
            .Init("Guardian Element 2",
                new State(
                    new State(
                        new Orbit(1.3, 9, target: "Oryx the Mad God 1", radiusVariance: 0),
                        new ConditionalEffect(ConditionEffectIndex.Invulnerable),
                        new Shoot(25, 3, 10, 0, coolDown: 1000),
                        new TimedTransition(20000, "Despawn")
                        ),
                    new State("Despawn", new Suicide()
                        )
                    )
            );
    }
}