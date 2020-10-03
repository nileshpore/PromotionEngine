# PromotionEngine
Promotion Engine - Sample application to create promotion and apply it against SKU.
Dependent Libraries 
- Newtonsoft.Json
- Tamarack

## Execution Flow
- **Promotion Process**
- Get Shopping cart as input
- Build Pipeline
  -  Initialize SKU Pricing
  -  Read all rules from repository with best rule as top.
  -  Default rule to set price
- Execute Pipeline  
  -  Execute first rule which will set default pricing for shopping cart item.
  -  Execute all configured rules and based on mathcing criteria apply promotion of respective rule.
  -  Execute last default rule for items which are not applicable for any promotion.
  -  Return total shopping cart amount.

## Possible Improvement
- Dependency Injection.
- Handling of custome rules, which can not be configured in Json.
- Rule logic improvement - currently all rules are executing for any shopping cart, it should execute only related rules.
- Error handling and logging.
- More Unit Tests.
