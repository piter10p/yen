#include "stdafx.h"
#include "AnimationManager.h"
#include "Error.h"
#include "Logger.h"

using namespace yen;

AnimationManager::AnimationManager()
{
}


AnimationManager::~AnimationManager()
{
}

void AnimationManager::setActualAnimation(AnimationManipulator manipulator)
{
	if (firstAnimationSetted == true)
		actualAnimation->pause();

	if (isAnimationAdded(manipulator))
	{
		actualAnimation = &manipulator.animationResource->animation;
		actualAnimation->restart();
		actualAnimation->pause();
		firstAnimationSetted = true;
		return;
	}

	ManipulatorError e;
	e.flag = Flag::ERROR_NOTHING_FOUND_ID;
	e.type = "AnimationManipulator";
	e.id = manipulator.getId();
	e.message = "Can not set actual animation. Animation of this id: " + std::to_string(e.id) + " don't exists.";
	Logger::errorLog(0, e.message);
	throw e;
}

void AnimationManager::addAnimation(AnimationManipulator manipulator)
{
	try
	{
		if (isAnimationAdded(manipulator))
		{
			ManipulatorError e;
			e.flag = Flag::ERROR_THING_WITH_THIS_ID_IS_ALREADY_EXISTS;
			e.type = "AnimationManipulator";
			e.id = manipulator.getId();
			throw e;
		}
		animations.push_back(manipulator.animationResource);
	}
	catch (ManipulatorError e)
	{
		e.message = "Can not add animation to Animation Manager. Animation with id: " + std::to_string(e.id) + " has already been added.";
		Logger::errorLog(0, e.message);
		throw e;
	}
}

void AnimationManager::removeAnimation(AnimationManipulator manipulator)
{
	for (unsigned int i = 0; i < animations.size(); i++)
	{
		if (animations[i]->getId() == manipulator.getId())
		{
			animations.erase(animations.begin() + i);
			return;
		}
	}
	ManipulatorError e;
	e.flag = Flag::ERROR_NOTHING_FOUND_ID;
	e.type = "AnimationManipulator";
	e.id = manipulator.getId();
	e.message = "Can not remove animation from AnimationManager. Animation with id: " + std::to_string(e.id) + " is not exists";
	Logger::errorLog(0, e.message);
	throw e;
}

Frame* AnimationManager::getActualFrame()
{
	return actualAnimation->getActualFrame();
}

void AnimationManager::setResourcesUsed()
{
	for (unsigned int i = 0; i < animations.size(); i++)
	{
		animations[i]->used();
	}
}

void AnimationManager::start()
{
	actualAnimation->start();
}

void AnimationManager::pause()
{
	actualAnimation->pause();
}

bool AnimationManager::isAnimationAdded(AnimationManipulator manipulator)
{
	for (unsigned int i = 0; i < animations.size(); i++)
	{
		if (animations[i]->getId() == manipulator.getId())
			return true;
	}
	return false;
}
