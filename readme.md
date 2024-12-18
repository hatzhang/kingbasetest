# 通过以下步骤重现

1. 修改Module里指定的链接串以符合本地环境
2. 运行  dotnet ef database update， 来做migration
3. 运行 dotnet run，应该就会看到如下的例外：

> Birth Date Kind Local
Unhandled exception. Microsoft.EntityFrameworkCore.DbUpdateException: An error occurred while saving the entity changes. See the inner exception for details.
 ---> System.ArgumentException: Cannot write DateTime with Kind=Local to KingbaseES type 'timestamp with time zone', only UTC is supported. Note that it's not possible to mix DateTimes with different Kinds in an array, range, or multirange. (Parameter 'value')
   at Kdbndp.Internal.Converters.DateTimeConverterResolver`1.Get(DateTime value, Nullable`1 expectedKbTypeId, Boolean validateOnly)
   at Kdbndp.Internal.Converters.DateTimeConverterResolver.<>c.<CreateResolver>b__0_0(DateTimeConverterResolver`1 resolver, DateTime value, Nullable`1 expectedKbTypeId)
   at Kdbndp.Internal.Converters.DateTimeConverterResolver`1.Get(T value, Nullable`1 expectedKbTypeId)        
   at Kdbndp.Internal.KbConverterResolver`1.GetAsObjectInternal(KbTypeInfo typeInfo, Object value, Nullable`1 expectedKbTypeId)
   at Kdbndp.Internal.KbResolverTypeInfo.GetResolutionAsObject(Object value, Nullable`1 expectedKbTypeId)     
   at Kdbndp.Internal.KbTypeInfo.GetObjectResolution(Object value)
   at Kdbndp.KdbndpParameter.ResolveConverter(KbTypeInfo typeInfo)
   at Kdbndp.KdbndpParameter.ResolveTypeInfo(KbSerializerOptions options, KdbndpConnector connector)
   at Kdbndp.KdbndpParameterCollection.ProcessParameters(KdbndpConnector conn, KbSerializerOptions options, Boolean validateValues, CommandType commandType)
   at Kdbndp.KdbndpCommand.ExecuteReader(Boolean async, CommandBehavior behavior, CancellationToken cancellationToken)
   at Kdbndp.KdbndpCommand.ExecuteReader(Boolean async, CommandBehavior behavior, CancellationToken cancellationToken)
   at Kdbndp.KdbndpCommand.ExecuteReader(CommandBehavior behavior)
   at Kdbndp.KdbndpCommand.ExecuteDbDataReader(CommandBehavior behavior)
   at Microsoft.EntityFrameworkCore.Storage.RelationalCommand.ExecuteReader(RelationalCommandParameterObject parameterObject)
   at Microsoft.EntityFrameworkCore.Update.ReaderModificationCommandBatch.Execute(IRelationalConnection connection)
   --- End of inner exception stack trace ---
   at Microsoft.EntityFrameworkCore.Update.ReaderModificationCommandBatch.Execute(IRelationalConnection connection)
   at Microsoft.EntityFrameworkCore.Update.ReaderModificationCommandBatch.Execute(IRelationalConnection connection)
tion)
   at Microsoft.EntityFrameworkCore.Update.Internal.BatchExecutor.Execute(IEnumerable`1 commandBatches, IRelationalConnection connection)
   at Microsoft.EntityFrameworkCore.Storage.RelationalDatabase.SaveChanges(IList`1 entries)
ionalConnection connection)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.SaveChanges(IList`1 entriesToSave)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.SaveChanges(StateManager stateManager, Boolean acceptAllChangesOnSuccess)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.<>c.<SaveChanges>b__112_0(DbContext _, ValueTuple`2 t)  
   at Kdbndp.EntityFrameworkCore.KingbaseES.Storage.Internal.KdbndpExecutionStrategy.Execute[TState,TResult](TState state, Func`3 operation, Func`3 verifySucceeded)
   at Microsoft.EntityFrameworkCore.ChangeTracking.Internal.StateManager.SaveChanges(Boolean acceptAllChangesOnSuccess)
   at Microsoft.EntityFrameworkCore.DbContext.SaveChanges(Boolean acceptAllChangesOnSuccess)
   at Microsoft.EntityFrameworkCore.DbContext.SaveChanges()
   at Modules.TestKdbndp_efcode() in D:\Projects\gaspower\kingbasetest\kingbasetest\Modules.cs:line 38
   at Program.<Main>$(String[] args) in D:\Projects\gaspower\kingbasetest\kingbasetest\Program.cs:line 4