<h1 align="center" style="border-bottom: none;">L-system for unity📦 </h1>
<h3 align="center">A simple and robust solution for procedure generation</h3>
<p align="center">
  <a href="https://github.com/semantic-release/semantic-release/actions?query=workflow%3ATest+branch%3Amaster">
    <img alt="Build states" src="https://github.com/semantic-release/semantic-release/workflows/Test/badge.svg">
  </a>
  <a href="https://github.com/semantic-release/semantic-release">
    <img alt="semantic-release: angular" src="https://img.shields.io/badge/semantic--release-angular-e10079?logo=semantic-release">
  </a>
  <a href="LICENSE">
    <img alt="License" src="https://img.shields.io/badge/License-MIT-blue.svg">
  </a>
</p>
<p align="center">
  <a href="package.json">
    <img alt="Version" src="https://img.shields.io/github/package-json/v/OpenSourceUnityPackage/LSystem">
  </a>
  <a href="#LastActivity">
    <img alt="LastActivity" src="https://img.shields.io/github/last-commit/OpenSourceUnityPackage/LSystem">
  </a>
</p>

<p align="center">
  <img height="300" width="300" src="https://user-images.githubusercontent.com/55276408/178099581-f2ed15a1-b1ee-43bf-a5c7-8e923eabb277.png" />
  <img height="300" width="300" src="https://user-images.githubusercontent.com/55276408/178099583-7803ed7f-9c37-44c4-bc4e-b8ae6d0f2ad1.png" />
  <img height="300" width="300" src="https://user-images.githubusercontent.com/55276408/178099584-aa1a1911-e007-424d-8cb8-bdbc3185d1e9.png" />
</p>

## What is it ?
An L-system or Lindenmayer system is a tool for creating a grammatical sequence based on rules. An L-system consists of an alphabet of symbols that can be used to create strings, a collection of production rules that expand each symbol into a larger string of symbols, an initial "axiom" string from which to begin construction, and a mechanism for translating the generated strings into geometric structures.  
This sequence can be used later by a reader for procedural generation purposes.

## Examples :
Let's look at a simple case to understand the algorithm.  

**Example 1: Algae**  
    variables : A B  
    boot sequence : A  
    rules  : (A → AB), (B → A)  

which produces:  
    n = 0 : A  
    n = 1 : AB (A → AB)  
    n = 2 : ABA (A → AB) + (B → A) + (A → AB)  
    n = 3 : ABAAB  
    n = 4 : ABAABABA  
    n = 5 : ABAABABAABAAB  
    n = 6 : ABAABABAABAABABAABABA  
    n = 7 : ABAABABAABAABABAABABAABAABABAABAAB  
    
Let's look at an example where we will be executing code using a generated sequence:   

**Example 2: Fractal plant**  
See also: Barnsley fern  
    variables : X F  
    constants : + − [ ]  
    start  : X  
    rules  : (X → F+[[X]-X]-F[-FX]+X), (F → FF)  
    angle  : 25°  

Here, F means "draw forward", − means "turn right 25°", and + means "turn left 25°". X does not correspond to any drawing action and is used to control the evolution of the curve. The square bracket "[" corresponds to saving the current values for position and angle, which are restored when the corresponding "]" is executed.  
This example with a bit of random give the image illustrated above.
    
## How to use this package ?
An advanced application of this package is demonstrated in the Sample folder with a unity scene.  
To integrate this package, add it to your project using the unity package manager and the git url or download it and insert it into your project (you will miss the update).  

The functionality of L-System is located in the static LSystem class. You can therefore call them whenever you want.
To use its functions, you will have to create your own class inherited from the given interface.
Let the demonstration and the commentary guide you.

Here an example of usage with sctipable object:  
<p align="center">
  <img src="https://user-images.githubusercontent.com/55276408/178115240-bf386582-c930-4fa3-9453-8bbd5585fd43.png" />
</p>

## How to contribute ?
To contribute, you can fork this repository and submit your merge request in the development branch. 
Please note that you need to use Andular typo to integrate your feature/repair into the changelog and create a new version.

### Angular typo
```
<type>(<scope>): <short summary>
  │       │             │
  │       │             └─⫸ Summary in present tense. Not capitalized. No period at the end.
  │       │
  │       └─⫸ Commit Scope: could be anything specifying title of the commit change in change log
  │
  └─⫸ Commit Type: feat, fix or perf, it will appear in the changelog.
              Build, ci, docs, style, refactor and test for non-changelog related tasks
```

The `<type>` and `<summary>` fields are mandatory, the `(<scope>)` field is optional.


#### Type

Must be one of the following:
* Visible in changelog: 
  * **feat**: A new feature
  * **fix**: A bug fix
  * **perf**: A code change that improves performance

* Non-changelog related tasks
  * **build**: Changes that affect the build system or external dependencies (example scopes: gulp, broccoli, npm)
  * **ci**: Changes to our CI configuration files and scripts (examples: CircleCi, SauceLabs)
  * **docs**: Documentation only changes
  * **refactor**: A code change that neither fixes a bug nor adds a feature
  * **test**: Adding missing tests or correcting existing tests
  
For example:
  - feat(FeatureName): create new feature
  - fix(Medium): fix an error
  - docs: update readme

For more information [see](https://github.com/angular/angular/blob/master/CONTRIBUTING.md#-commit-message-format) and for resume [see](https://github.com/conventional-changelog/conventional-changelog/tree/master/packages/conventional-changelog-angular)
