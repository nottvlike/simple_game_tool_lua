require 'Common.Script.Class'

b3 = {
	VERSION = "0.2.0",

	--Returning status
	SUCCESS = 1,
	FAILURE = 2,
	RUNNING = 3,
	ERROR 	= 4,
	MOVING  = 5,
	DASH 	= 6,
	
	--Node categories
	COMPOSITE = "composite",
	DECORATOR = "decorator",
	ACTION = "action",
	CONDITION = "condition",

	createUUID = CreateUUID,

	Class = Class,
}

require 'Common.Script.Behavior.core.Action'
require 'Common.Script.Behavior.core.BaseNode'
require 'Common.Script.Behavior.core.Behavior'
require 'Common.Script.Behavior.core.Blackboard'
require 'Common.Script.Behavior.core.Composite'
require 'Common.Script.Behavior.core.Condition'
require 'Common.Script.Behavior.core.Decorator'
require 'Common.Script.Behavior.core.Decorator'
require 'Common.Script.Behavior.core.Tick'

require 'Common.Script.Behavior.actions.Error'
require 'Common.Script.Behavior.actions.Failer'
require 'Common.Script.Behavior.actions.Runner'
require 'Common.Script.Behavior.actions.Succeeder'
require 'Common.Script.Behavior.actions.Wait'
require 'Common.Script.Behavior.actions.Move'
require 'Common.Script.Behavior.actions.Dash'

require 'Common.Script.Behavior.composites.MemPriority'
require 'Common.Script.Behavior.composites.MemSequence'
require 'Common.Script.Behavior.composites.Priority'
require 'Common.Script.Behavior.composites.Sequence'

require 'Common.Script.Behavior.decorators.Inverter'
require 'Common.Script.Behavior.decorators.Limiter'
require 'Common.Script.Behavior.decorators.MaxTime'
require 'Common.Script.Behavior.decorators.Repeater'
require 'Common.Script.Behavior.decorators.RepeatUntilFailure'
require 'Common.Script.Behavior.decorators.RepeatUntilSuccess'