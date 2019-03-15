# Nelnet Coding Exercise

Please fork this repository and enhance it with the following requirements:

## Requirement #1
Pets shall have a weight.  Use the following data for the existing test objects:

- Garfield: 20.0
- Odie: 15.0
- Peter Parker: 0.5
- Kaa: 25.0
- Nemo: 0.5
- Alpha: 0.1
- Splinter: 0.5
- Coco: 6.0
- Tweety: 0.05

## Requirement #2
Person shall have a prefered weight.  Weight classes are defined as:

- Extra Small: 0 < x <= 1.0
- Small: 1.0 < x <= 5.0
- Medium: 5.0 < x <= 15.0
- Large: 15.0 < x <= 30.0
- Extra Large: 30.0 < x

Use the following data for the existing test objects:

- Dalinar: Medium
- Kaladin: Extra Small

## Requirement #3
All preferences shall be overridable.

## Requirement #4
A person shall be able to have unlimited number of overrides

## Requirement #5
Pet decisions shall be made using the following hierarchy (1 overrides 2, 2 overrides 3, etc.):

1. Type
2. Classification
3. Weight
4. Default Type/Classification/Weight on person object
