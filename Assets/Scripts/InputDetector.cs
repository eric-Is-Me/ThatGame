﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum InputDirection {
    Left, Right, Up, Down, None
}

public interface InputDetector{
    InputDirection? DetectInputDirection();
}
