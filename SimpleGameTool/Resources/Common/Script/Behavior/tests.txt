require 'Common.Script.BehaviorTree.b3'

local action = b3.Action.New()
print(action.category)

local baseNode = b3.BaseNode.New()
print(baseNode.id)
print(baseNode.name)
print(baseNode.title)
print(baseNode.description)
print(baseNode.parameters)
print(baseNode.properties)

local behaviorTree = b3.BehaviorTree.New()
print(behaviorTree.id)
print(behaviorTree.title)
print(behaviorTree.description)
print(behaviorTree.properties)
print(behaviorTree.root)
print(behaviorTree.debug)

local blackBoard = b3.Blackboard.New()
print(blackBoard._baseMemory)
print(blackBoard._treeMemory)

local composite = b3.Composite.New()
print(composite.children)

local condition = b3.Condition.New()

local decorator = b3.Decorator.New()
print(decorator.child)

local tick = b3.Tick.New()
print(tick.tree)
print(tick.debug)
print(tick.target)
print(tick.blackboard)
print(tick._openNodes)
print(tick._nodeCount)

local error = b3.Error.New()
print(error.name)

local failer = b3.Failer.New()
print(failer.name)

local runner = b3.Runner.New()
print(runner.name)

local succeeder = b3.Succeeder.New()
print(succeeder.name)

local wait = b3.Wait.New()
print(wait.name)
print(wait.id)
print(wait.title)
print(wait.description)

local memPriority = b3.MemPriority.New()
print(memPriority.name)

local memSequence = b3.MemSequence.New()
print(memSequence.name)

local priority = b3.Priority.New()
print(priority.name)

local sequence = b3.Sequence.New()
print(sequence.name)
print(sequence.id)
print(sequence.title)

local inverter = b3.Inverter.New()
print(inverter.name)
print(inverter.id)
print(inverter.title)

local maxTime = b3.MaxTime.New()
print(maxTime.name)
print(maxTime.id)

local repeater = b3.Repeater.New()
print(repeater.name)
print(repeater.id)

local repeatUntilFailure = b3.RepeatUntilFailure.New()
print(repeatUntilFailure.name)
print(repeatUntilFailure.id)

local repeatUntilSuccess = b3.RepeatUntilSuccess.New()
print(repeatUntilSuccess.name)
print(repeatUntilSuccess.id)

