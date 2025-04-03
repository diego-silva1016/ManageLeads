import { TabPane } from 'semantic-ui-react'
import LeadCard from '../../../components/LeadCard'
import { getAcceptedLeads } from '../../../services/leadsService'

function AcceptedList() {
  const { data: leads, refetch } = getAcceptedLeads()
  return (
    <TabPane active={true} attached={false} style={{ background: "transparent", border: "none", boxShadow: "none", padding: 0 }}>
        {leads && leads.map(lead => <LeadCard key={lead.id} lead={lead} isAcceptedList={true} refetch={refetch}/>)}
    </TabPane>
  )
}

export default AcceptedList
