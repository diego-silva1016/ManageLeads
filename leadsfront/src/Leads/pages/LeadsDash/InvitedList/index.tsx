import { TabPane } from 'semantic-ui-react'
import LeadCard from '../../../components/LeadCard'
import { getInviteLeads } from '../../../services/leadsService'

function InvitedList() {
  const { data: leads,  refetch } = getInviteLeads()
  return (
    <TabPane active={true} attached={false} style={{ background: "transparent", border: "none", boxShadow: "none", padding: 0 }}>
        {leads && leads.map(lead => <LeadCard key={lead.id} lead={lead} isAcceptedList={false} refetch={refetch}/>)}
    </TabPane>
  )
}

export default InvitedList
