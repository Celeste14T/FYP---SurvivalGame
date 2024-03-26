namespace SurvivalPropertiesSystem.Scripts
{
    [System.Serializable]
    public enum Condition
    {
        /// <summary>
        /// Trigger impact when The current value is less than the condition value
        /// </summary>
        LessThan,

        /// <summary>
        /// Trigger impact when The current value is less than or equals to the condition value
        /// </summary>
        LessOrEqualsTo,

        /// <summary>
        /// Trigger impact when The current value equals to the condition value
        /// </summary>
        EqualsTo,

        /// <summary>
        /// Trigger impact when The current value is equals to or greater than the condition value
        /// </summary>
        EqualOrGreaterThan,

        /// <summary>
        /// Trigger impact when The current value is greater than the condition value
        /// </summary>
        GreaterThan
    }
}
