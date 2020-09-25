\<?xml version="1.0" encoding="utf-8" ?>
\<hibernate-mapping xmlns = "urn:nhibernate-mapping-2.2"
   assembly = "<assemblyName>" namespace = "<namespace>">

  \<class name="<className>" table="<tableName>" lazy="true">
    \<id name = "Id" column="oid">
      \<generator class = "hilo"/>
    \</id>

    <properties:{property | 
    \<property name="<property.PropertyName>" type="<property.CsType>">
      \<column name="<property.ColumnName>" index="<property.IndexName>"  sql-type="<property.SqlType>"/>
    \</property>
    }>

    <bags:{bag | 
    \<bag name="<bag.BagName>" lazy="true" cascade="all-delete-orphan" fetch="select">
      \<key column="<bag.BagFKColumnName>">\</key>
      \<one-to-many class="<bag.BagClassName>">\</one-to-many>
    \</bag>
    }>

  \</class>
\</hibernate-mapping>
