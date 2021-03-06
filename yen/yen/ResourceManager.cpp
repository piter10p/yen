#include "stdafx.h"
#include "ResourceManager.h"
#include "Error.h"

using namespace yen;

ResourceManager::ResourceManager()
{
	addDefaultLanguage();
}


ResourceManager::~ResourceManager()
{
	clearAllResources();
	clearLanguages();
}

AnimationManipulator ResourceManager::addAnimationResource(AnimationResourceDef def)
{
	AnimationResource *resource = new AnimationResource(def, getNewId());
	animationResources.push_back(resource);

	AnimationManipulator manipulator;
	manipulator.animationResource = resource;
	//manipulator.id = resource->getId();
	manipulator.setId(resource->getId());
	manipulator.animationResource->setFrameRate(def.frameRate);
	return manipulator;
}

void ResourceManager::removeAnimationResource(AnimationManipulator manipulator)
{
	for (unsigned int i = 0; i < animationResources.size(); i++)
	{
		if (isIdSame(&manipulator, animationResources[i]))
		{
			animationResources.erase(animationResources.begin() + i);
			delete manipulator.animationResource;
			return;
		}
	}
	Error e;
	e.flag = Flag::ERROR_NOTHING_FOUND_ID;
	e.message = "Can not remove Animation Resource. No thing with id: \"" + std::to_string(manipulator.getId()) + "\" was found.";
	Logger::errorLog(0, e.message);
	throw e;
}

StringManipulator ResourceManager::addStringResource(std::string path)
{
	StringResource *resource = new StringResource(path, getNewId(), actualLanguage);
	StringManipulator manipulator;
	manipulator.resource = resource;
	manipulator.id = resource->getId();
	stringResources.push_back(resource);

	return manipulator;
}

void ResourceManager::removeStringResource(StringManipulator manipulator)
{
	for (unsigned int i = 0; i < stringResources.size(); i++)
	{
		if (isIdSame(&manipulator, stringResources[i]))
		{
			stringResources.erase(stringResources.begin() + i);
			delete manipulator.resource;
			return;
		}
	}
	Error e;
	e.message = "Can not remove String Resource. No thing with id: \"" + std::to_string(manipulator.id) + "\" was found.";
	e.flag = Flag::ERROR_NOTHING_FOUND_ID;
	Logger::errorLog(0, e.message);
	throw e;
}

std::string ResourceManager::getString(StringManipulator manipulator, std::string stringName)
{
	return manipulator.resource->getString(stringName);
}

FontManipulator ResourceManager::addFontResource(std::string path)
{
	FontResource *resource = new FontResource(path);
	resource->setId(getNewId());
	fontResources.push_back(resource);

	FontManipulator manipulator;
	manipulator.resource = resource;
	manipulator.setId(resource->getId());

	return manipulator;
}
void ResourceManager::removeFontResource(FontManipulator manipulator)
{
	for (unsigned int i = 0; i < fontResources.size(); i++)
	{
		if (isIdSame(&manipulator, fontResources[i]))
		{
			fontResources.erase(fontResources.begin() + i);
			delete manipulator.resource;
			return;
		}
	}
	Error e;
	e.message = "Can not remove Font Resource. No thing with id: \"" + std::to_string(manipulator.getId()) + "\" was found.";
	e.flag = Flag::ERROR_NOTHING_FOUND_ID;
	Logger::errorLog(0, e.message);
	throw e;
}

void ResourceManager::addLanguage(const std::string code)
{
	try
	{
		if (isLanguageAlreadyAdded(code))
		{
			Error e;
			e.flag = Flag::ERROR_LANGUAGE_WITH_THIS_CODE_ALREADY_EXISTS;
			throw e;
		}

		Language *lang = new Language(code);
		languages.push_back(lang);
	}
	catch (Error e)
	{
		if (e.flag == Flag::ERROR_LANGUAGE_WITH_THIS_CODE_ALREADY_EXISTS)
			Logger::errorLog(0, "Can not add language with code: \"" + code + "\". Language with that code already exists.");
		else
			Logger::undefinedErrorLog("ResourceManager::addLanguage()");
	}
	catch (...)
	{
		Logger::undefinedErrorLog("ResourceManager::addLanguage()");
	}
}

void ResourceManager::changeActiveLanguage(std::string code)
{
	try
	{
		for (unsigned int i = 0; i < languages.size(); i++)
		{
			if (languages[i]->getCode() == code)
				actualLanguage = languages[i];
		}
	}
	catch (...)
	{
		Logger::errorLog(0, "Can not change active language. Possibly index is out of range.");
	}
}

void ResourceManager::resetResourceUsage()
{
	for (unsigned int i = 0; i < animationResources.size(); i++)
	{
		animationResources[i]->resetUsed();
	}

	for (unsigned int i = 0; i < stringResources.size(); i++)
	{
		stringResources[i]->resetUsed();
	}

	for (unsigned int i = 0; i < fontResources.size(); i++)
	{
		fontResources[i]->resetUsed();
	}
}

bool ResourceManager::test()
{
	try
	{
		AnimationResourceDef def;
		def.path = "ASD";

		AnimationManipulator manipulator = addAnimationResource(def);
		removeAnimationResource(manipulator);
		return true;
	}
	catch (...)
	{
		return false;
	}	
}

bool ResourceManager::isIdSame(Id* manipulator, Resource* resource)
{
	if (manipulator->getId() == resource->getId())
		return true;
	return false;
}

bool ResourceManager::isLanguageAlreadyAdded(const std::string code)
{
	for (unsigned int i = 0; i < languages.size(); i++)
	{
		if (languages[i]->getCode() == code)
			return true;
	}
	return false;
}

void ResourceManager::clearAllResources()
{
	for (unsigned int i = 0; i < animationResources.size(); i++)
	{
		delete animationResources[i];
	}
	animationResources.clear();

	for (unsigned int i = 0; i < stringResources.size(); i++)
	{
		delete stringResources[i];
	}
	stringResources.clear();

	for (unsigned int i = 0; i < fontResources.size(); i++)
	{
		delete fontResources[i];
	}
	fontResources.clear();
}

void ResourceManager::clearLanguages()
{
	for (unsigned int i = 0; i < languages.size(); i++)
	{
		delete languages[i];
	}
	languages.clear();
}

void ResourceManager::addDefaultLanguage()
{
	Language *lang = new Language("default");
	actualLanguage = lang;
	languages.push_back(lang);
}

void ResourceManager::loadResources()
{
	for (unsigned int i = 0; i < animationResources.size(); i++)
	{
		animationResources[i]->loadOperations();
	}

	for (unsigned int i = 0; i < stringResources.size(); i++)
	{
		stringResources[i]->loadOperations();
	}

	for (unsigned int i = 0; i < fontResources.size(); i++)
	{
		fontResources[i]->loadOperations();
	}
}